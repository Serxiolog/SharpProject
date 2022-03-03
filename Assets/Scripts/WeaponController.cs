using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject ball;
    public Transform endPoint;
    public float forceShoot;
    public int balls;
    public Shooting_Counter points;
    private bool isDead = false;

    private void Start()
    {
        balls = 10;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal"); 
        transform.Rotate(new Vector3(-vertical, 0, -horizontal));
        points.counter_bullets = balls;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall" || collision.transform.tag == "Cube")
        {
            isDead = true;
        }
    }

    public void Shoot()
    {
        if (balls > 0)
        {
            var newBall = Instantiate(ball, endPoint.position, Quaternion.identity);
            Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * forceShoot, ForceMode.Impulse);
            if (isDead)
                Destroy(newBall);
            balls--;
        }
    }

    public void Reload()
    {
        balls = 10;
    }

    
}
