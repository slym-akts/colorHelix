using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [Header("top hareketi")]
    public Rigidbody rb;
    public float jumpForce;

    public GameObject stainSp;

    [Header("top rengi")]
    public Material[] materials;
    private string materialColor;

    [Header("game maneger")]
    private gameManeger gm;
    private int num=15;
    void Start()
    {
        gm=GameObject.FindAnyObjectByType<gameManeger>();
        colorChange();
    }
    
    void Update()
    {
       materialColor=GetComponent<MeshRenderer>().material.name;//top rengi
    } 
    

   
    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up*jumpForce);

        GameObject stain=Instantiate(stainSp,transform.position+new Vector3(0f,-0.2f,0f),transform.rotation);
        stain.transform.SetParent(other.gameObject.transform);//iz çıkması

        string otherMaterial= other.gameObject.GetComponent<MeshRenderer>().material.name;//zemin rengi 

        if (materialColor==otherMaterial)
        {
            Destroy(other.gameObject);
            colorChange();
            gm.spawnClyn(num);
            num+=5;
        }
        else if (otherMaterial=="ground (Instance)")
        {
            
        }
        else
        {
            gm.gameOver=true;
            Debug.Log("game over");
        }

    }
    void colorChange ()
    {
        Material randomColor=materials[Random.Range(0,materials.Length)];
        GetComponent<MeshRenderer>().material=randomColor;
    }
}
