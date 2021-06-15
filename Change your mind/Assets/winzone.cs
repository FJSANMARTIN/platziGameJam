using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winzone : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.sharedInstance.FinishGame();
        }
    }


}
