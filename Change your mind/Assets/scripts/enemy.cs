using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject BulletPreb;

    public GameObject personaje;

    private float LastShoot;

    public int health = 50;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        Vector3 direction = personaje.transform.position - transform.position;


        if (direction.x >= 0.0f) transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        else transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        float distance = Mathf.Abs(personaje.transform.position.x - transform.position.x);

        if (distance < 8.0f && Time.time > LastShoot + 2f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }


    void Shoot()
    {
        Vector3 direction = personaje.transform.position - transform.position;








        GameObject bullet = Instantiate(BulletPreb, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletscrip>().setDirection(direction);
    }

    public void Hit()
    {
        health = health - 10;
        if (health <= 0) Destroy(gameObject);
    }

}
