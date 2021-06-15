using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float maxSpeed = 5f;

    public float speed = 2f;

    public float jumpForce = 6f;

    public SpriteRenderer spriteRen;

    public int healthpoints;

    public const int INITIAL_HEALTH = 400, MIN_HEALTH = 0, MAX_HEALTH = 400;

    public GameObject bulletPreb;
    


    public float distancia = 1.3f;

    public bool grounded;

    private Rigidbody2D rgb;

    private Animator anim;

    public LayerMask groundMask;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();


        Physics2D.Raycast(transform.position, new Vector2(0,-distancia));

        StartGame();
    }
    public void StartGame()
    {
        GameManager.sharedInstance.GameStart();
        healthpoints = INITIAL_HEALTH;
    }
    
    void Update()
    {

      

        if(transform.localScale.x == -0.5f)
        {
            spriteRen.flipX = true;
        }
        if (transform.localScale.x == 0.5f)
        {
            spriteRen.flipX = false;
        }

     

        Debug.DrawRay(transform.position, new Vector2(0, -distancia), Color.red);


        anim.SetFloat("speed", Mathf.Abs(f: rgb.velocity.x));

        anim.SetBool("isOnTheGround", isTouchingTheGround());

        bool isTouchingTheGround()
        {
            if (Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask))
            {
                return true;
            }
            else return false;
        }
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        if (h < 0.0f) transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else if (h > 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        rgb.AddForce(Vector2.right * speed * h );


        if (rgb.velocity.x > maxSpeed)
        {

            rgb.velocity = new Vector2(maxSpeed, rgb.velocity.y);


        }

        if(rgb.velocity.x < -maxSpeed)
        {

            rgb.velocity = new Vector2(-maxSpeed, rgb.velocity.y);


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            jump();
                
               
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }


        void jump()
        {
            if (isTouchingTheGround())
            {
                rgb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
        }

       
        void shoot()
        {
            Vector3 direccion;



            if (transform.localScale.x == 0.5f) direccion = Vector3.right;
            else direccion = Vector3.left;
          
      
            

            GameObject bullet = Instantiate(bulletPreb,  transform.position + direccion * 0.1f , Quaternion.identity);
            bullet.GetComponent<bulletscrip>().setDirection(direccion);
        }

        bool isTouchingTheGround()
        {
            if (Physics2D.Raycast(this.transform.position, Vector2.down,2.0f, groundMask))
            {
                
                return true;
            }
            else return false;
        }


    }

    public void collectHealth(int points)
    {
        this.healthpoints += points;

        if(this.healthpoints >= MAX_HEALTH)
        {
            this.healthpoints = MAX_HEALTH;
        }


    }

    public void Die()
    {
        Debug.Log("se murio el personaje");
 
        GameManager.sharedInstance.GameOver();
    }

    public int getHealth()
    {
        return healthpoints;
    }

    public void Hit()
    {
  

        healthpoints = healthpoints - 5;

        if (healthpoints <= 0) Die();

    }
}
