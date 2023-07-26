using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smoothpass;// camera hareketi efekti için.
    void Start()
    {
        offset=transform.position-ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos=Vector3.Lerp(transform.position,offset+ball.position,smoothpass);
        transform.position=newpos;
    }
}
