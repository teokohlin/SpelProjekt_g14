using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRotation : MonoBehaviour
{
    public Transform obj;
    private Quaternion offset = new Quaternion(0, 180, 0, 0);
    
    void Start()
    {
        
    }


    private void Update()
    {
        transform.rotation = new Quaternion(0, (obj.rotation.y) * -1 , 0,0) * offset;
    }
}
