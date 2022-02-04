using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //public float verticalBobFrequency = 1f;
    //public float bobbingAmount = 1f;

    Vector3 startPosition;

    public dType dropType;
    [Tooltip("Hur mycket av resurser en *pickup* ger")]
    public int pickupAmount = 1;
    public enum dType
    {
        wood,
        stone,
        food
    }
    private void Start()
    {
        startPosition = new Vector3(transform.position.x, .5f, transform.position.z);
    }
    void Update()
    {
        //göra så att den kanske guppar lite, istället för att de spawnar på varandra och flyger iväg med rigidbodys
        //med andra ord, kan ta bort rigidbody

        ///////////////////////////////////DETTA UNDER

        //float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;

        //transform.position = startPosition + Vector3.up * bobbingAnimationPhase;

        ///////////////////////////////////DETTA ÖVER
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();

            switch (dropType)
            {
                case dType.wood:
                    p.AddWood(pickupAmount); //1 sålänge
                    break;
                case dType.stone:
                    p.AddStone(pickupAmount); //1 sålänge
                    break;
                case dType.food:
                    p.AddFood(pickupAmount); //1 sålänge, hade kanske kunnat göra att det e mer
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
