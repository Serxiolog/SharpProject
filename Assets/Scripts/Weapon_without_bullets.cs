using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_without_bullets : MonoBehaviour
{
    private Camera _camera;
    public LineRenderer lineRenderer;
    public Transform endPointWeapon;
    public Shooting_Counter points;
    void Start()
    {
        lineRenderer.positionCount = 2;
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (points.counter_bullets > 0)
            {
                RaycastHit hit;

                var fromPos = _camera.ViewportToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

                if (Physics.Raycast(fromPos, _camera.transform.forward, out hit))
                {
                    lineRenderer.SetPosition(0, endPointWeapon.position);
                    lineRenderer.SetPosition(1, hit.point);
                    StartCoroutine(ShowLine());

                    if (hit.transform.CompareTag("Cube"))
                    {
                        Destroy(hit.transform.gameObject);
                        points.counter_score++;
                    }

                }
                points.counter_bullets--;
            }
                
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            points.counter_bullets = 10;
        }
    }

    private IEnumerator ShowLine()
    {
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        lineRenderer.enabled = false;
    }
}
