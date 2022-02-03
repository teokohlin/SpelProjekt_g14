using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRendererBlocker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        other.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        other.GetComponent<MeshRenderer>().enabled = true;

    }
}
