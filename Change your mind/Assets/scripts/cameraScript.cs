using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject personaje;
  
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
      
    }

    
    void Update()
    {
        Vector3 position = transform.position;
        position.x = personaje.transform.position.x;
        transform.position = position;
    }
}
