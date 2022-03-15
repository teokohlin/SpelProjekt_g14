using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum dType
{
    wood,
    stone,
    food
}



public class Pickup : MonoBehaviour
{
    //public float verticalBobFrequency = 1f;
    //public float bobbingAmount = 1f;

    Vector3 startPosition;
    private bool alreadyPickedUp;

    private AudioManager audioManager;

    public dType dropType;
    [Tooltip("Hur mycket av resurser en *pickup* ger")]
    public int pickupAmount = 1;

    private float maxSpeed = 10;
    private float speed = 0;
    private Transform player;
    
    private void Start()
    {
        startPosition = new Vector3(transform.position.x, .5f, transform.position.z);
        audioManager = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<Player>().gameObject.transform;


    }
    void Update()
    {
        if (speed < 40)
        {
            speed += Time.deltaTime * 10;
        }
        transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.position, speed * Time.deltaTime );

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyPickedUp)
        {
            if (other.isTrigger)
            {
                return;
            }
            alreadyPickedUp = true;
            Player p = other.GetComponent<Player>();
            
            p.AddResource(pickupAmount,dropType);

            audioManager.interactablesAudio.PickupAudio(this.gameObject); 

            //switch (dropType)
            //{
            //    case dType.wood:
            //        p.AddWood(pickupAmount); //1 sålänge
            //        break;
            //    case dType.stone:
            //        p.AddStone(pickupAmount); //1 sålänge
            //        break;
            //    case dType.food:
            //        p.AddFood(pickupAmount); //1 sålänge, hade kanske kunnat göra att det e mer
            //        break;
            //    default:
            //        break;
            //}
            Destroy(gameObject);
        }
        // else if (other.CompareTag("Woodworker") && !alreadyPickedUp)
        // {
        //     alreadyPickedUp = true;
        //     WoodWorker w = other.GetComponent<WoodWorker>();
        //     if (dropType == dType.wood)
        //     {
        //         w.CollectWood(pickupAmount);
        //     }
        //     Destroy(gameObject);
        // }
        
    }
}


