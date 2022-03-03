using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Bonus : MonoBehaviour
{
    public Shooting_Counter points;
    private bool isTaken = false;


    void Update()
    {
        transform.Rotate(new Vector3(0, transform.rotation.y + 2, 0));

        if (isTaken)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            points.counter_score += 10;
            
            
        }
    }
}
