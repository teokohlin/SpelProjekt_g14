using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float verticalBobFrequency = 1f;
    public float bobbingAmount = 1f;

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
        //g�ra s� att den kanske guppar lite, ist�llet f�r att de spawnar p� varandra och flyger iv�g med rigidbodys
        //med andra ord, kan ta bort rigidbody

        ///////////////////////////////////DETTA UNDER

        //float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;

        //transform.position = startPosition + Vector3.up * bobbingAnimationPhase;

        ///////////////////////////////////DETTA �VER
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();

            switch (dropType)
            {
                case dType.wood:
                    p.AddWood(pickupAmount); //1 s�l�nge
                    break;
                case dType.stone:
                    p.AddStone(pickupAmount); //1 s�l�nge
                    break;
                case dType.food:
                    p.AddFood(pickupAmount); //1 s�l�nge, hade kanske kunnat g�ra att det e mer
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
