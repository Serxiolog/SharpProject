using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Checker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
