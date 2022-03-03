using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_For_3D : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    public Shooting_Counter points;

    private float x_coord;
    private float y_coord;
    private float z_coord;
    private bool isBroken;

    private void Start()
    {
        x_coord = transform.position.x;
        y_coord = transform.position.y;
        z_coord = transform.position.z;
        isBroken = false;
    }

    private void Update()
    {
        if (transform.position.x >= x_coord + 10)
        {
            direction = -1;
        }
        else if (transform.position.x <= x_coord - 10)
        {
            direction = 1;
        }

        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * direction,
            y_coord, z_coord);

        if (isBroken)
        {
            Destroy(gameObject);
        }
    }

    public void isShooted()
    {
        points.counter_score++;
        isBroken = true;
    }

}
