using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_For_3D : MonoBehaviour
{
    public GameObject ball;
    public Transform endPoint;
    public float forceShoot;
    public int balls;
    public Shooting_Counter points;

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

        points.counter_bullets = balls;
    }


    public void Shoot()
    {
        if (balls > 0)
        {
            var newBall = Instantiate(ball, endPoint.position, Quaternion.identity);
            Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * forceShoot, ForceMode.Impulse);
            Destroy(newBall, 5);
            balls--;
        }
    }

    public void Reload()
    {
        balls = 10;
    }


}
