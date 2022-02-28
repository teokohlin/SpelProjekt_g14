using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Linq;
public class WoodWorker : MonoBehaviour
{
    public DayNightCycle Dnc;
    public GameObject WoodStack;
    private Vector3 stackPos; 
    public Transform dropZone;
    public Transform dropPoint;
    public Transform home;
    public List<GameObject> trees;
    public int Energy = 3;
    private int teleports;
    private float speed = 10f;
    private Vector3 treePos;
    private bool killedWood;
    private int collectedWood = 0;
    private Vector3 newdirection;
    private Vector3 targetDir;
    private int targets;
    private bool drop;
    private int days;
    private void Start()
    {
        Dnc = FindObjectOfType<DayNightCycle>();
        Dnc.DayPast += RefillEnergy;
    }

    private void OnEnable()
    {
        Energy--;
        trees = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tree"));
        SortByDistance();
        MoveToTree();
        targets = 3;
    }

    private void Update()
    {
        //speed
        float step = speed * Time.deltaTime;
        
        if (trees.Count > 0 && targets > 0)
        {
            //Move towards tree
            transform.position = 
                Vector3.MoveTowards(transform.position, treePos,step);
        
            //Rotate towards tree
            targetDir = treePos - transform.position;
            newdirection = 
                Vector3.RotateTowards
                    (transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdirection);
        }
        
        //Chop one tree and move on to the next
        if (transform.position == treePos)
        {
            if (!killedWood)
            {
                ChopWood();
            }
            SortByDistance();
            MoveToTree();
        }
        //When no trees left or targets is 0 move to drop point
        if (trees.Count == 0 || targets == 0 && !drop)
        {
            //Rotate towrds drop point
            targetDir = dropZone.position - transform.position;
            newdirection = 
                Vector3.RotateTowards
                    (transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdirection);
            //Move towards drop point
            transform.position = 
                Vector3.MoveTowards(transform.position, dropZone.position, step);
            if (transform.position == dropZone.position)
            {
                DropStack();
            }

            if (trees.Count < targets)
            {
                targets = 0;
            }
        }
        
        if (drop)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, home.position, step);
        }
        if (transform.position == home.position)
        {
            drop = false;
            enabled = false;
        }
    }

    private void RefillEnergy()
    {
        Energy = 3;
    }
    void DropStack()
    {
        if (collectedWood > 0)
        {
            WoodStack.GetComponent<Pickup>().pickupAmount = collectedWood;
            GameObject.Instantiate(WoodStack, dropPoint.position, WoodStack.transform.rotation);
            collectedWood = 0;
            drop = true;
        }
    }
    public void CollectWood(int amount)
    {
        collectedWood += amount;
    }
    private void MoveToTree()
    {
        foreach (GameObject tree in trees)
        {
            Vector3 vector = new Vector3(tree.transform.position.x, 0.5f, tree.transform.position.z);
            treePos = vector;
            break;
        }
    }

    void ChopWood()
    {
        foreach (GameObject tree in trees)
        {
            int t = tree.GetComponent<Tree>().dropAmount;
            CollectWood(t);
            tree.GetComponent<Tree>().LoseHealth(50);
            targets--;
            killedWood = true;
            if (killedWood)
            {
                trees.Remove(tree);
                killedWood = false;
            }
            break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pickup>() != null)
        {
            if (other.GetComponent<Pickup>().dropType == dType.wood)
            {
                Destroy(other.gameObject);
            }
        }
        

    }

    private void SortByDistance()
    {
        foreach (GameObject tree in trees)
        {
            trees = trees.OrderBy((tree) => (tree.transform.position - transform.position).sqrMagnitude).ToList();
        }
    }
}
