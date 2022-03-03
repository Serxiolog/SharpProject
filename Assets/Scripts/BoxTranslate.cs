using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTranslate : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    public Shooting_Counter point;


    private void Update()
    {
        if (transform.position.x >= 8)
        {
            direction = -1;
        }
        else if (transform.position.x <= -8)
        {
            direction = 1;
        }

        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * direction,
            transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            point.counter_score += 1;
    }

}
