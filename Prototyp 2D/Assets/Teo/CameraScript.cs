using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    private Vector3 target, mousepos, refVel, shakeOffset;

    private float cameraDis = 3.5f;
    private float smoothTime = 0.1f, zStart;

    private float shakeMag, shaketimeend;
    private Vector3 shakevector;
    private bool shaking;
    void Start()
    {
        target = player.position;
        zStart = transform.position.z;
    }

    void Update()
    {
        mousepos = CaptureMousePos();
        target = Updatetargetpos();
        UpdateCameraPos();
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized;
        }

        return ret;
    }

    Vector3 Updatetargetpos()
    {
        Vector3 mouseOffset = mousepos * cameraDis;
        Vector3 ret = player.position + mouseOffset;
        ret.z = zStart;
        return ret;
    }

    void UpdateCameraPos()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
        transform.position = tempPos;
    }
}
