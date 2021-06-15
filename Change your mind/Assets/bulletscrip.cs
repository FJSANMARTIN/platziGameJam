using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscrip : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgbody;
    public AudioClip sound;

    private Vector2 Direction;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rgbody.velocity = Direction * speed;
    }


    public void setDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        character Personaje = collision.GetComponent<character>();
        enemy enemigo = collision.GetComponent<enemy>();

        if (collision.tag == "Player")
        {
            Personaje.Hit();
            
        }
        if (enemigo != null)
        {
            enemigo.Hit();
           

        }

        DestroyBullet();
        
    }
 


    
}
