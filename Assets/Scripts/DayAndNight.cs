using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    public Light sun;
    public bool X_rotate;
    public bool Y_rotate;

    private void OnTriggerStay(Collider other)
    {
        if (Y_rotate)
            sun.transform.rotation *= Quaternion.Euler(0, 1, 0);
        if (X_rotate)
            sun.transform.rotation *= Quaternion.Euler(1, 0, 0);
    }
}
