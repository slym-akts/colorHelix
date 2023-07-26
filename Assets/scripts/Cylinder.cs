using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    
    public float speedRot;

    private float moveX;
    
    void Update()
    {
        moveX=Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f,moveX*speedRot*Time.deltaTime,0f);
        }
    }
}
