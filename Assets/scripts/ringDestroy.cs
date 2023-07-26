using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ringDestroy : MonoBehaviour
{
    
    private gameManeger gm;
   
    
    private void Start()
    {
        gm=GameObject.FindAnyObjectByType<gameManeger>();
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        gm.gameScore(1);
       
        
    }
    
   

}
