using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> points;
    public float speedWalk;
    public float speedRun;

    public float distanceDamage;
    public float distanceVisibility;
    public Transform player;
    public Shooting_Counter score;

    private int indexCurPoint = 0;
    public Animator animator;
    public float timeReloadAttack;
    private bool isReload = false;
    private void Update()
    {
        float distanceEnemyToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceEnemyToPlayer < distanceDamage)
        {
            animator.SetBool("Walk Forward", false);
            animator.SetBool("Run Forward", false);
            if (!isReload)
            {
                animator.SetTrigger("Attack 01");
                score.HP--;
                StartCoroutine(Reload());
            }
        }
        else if (distanceEnemyToPlayer < distanceVisibility)
        {
            animator.SetBool("Walk Forward", false);
            animator.SetBool("Run Forward", true);
            Vector3 newPlayerPos = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(newPlayerPos);
            transform.Translate(Vector3.forward * speedRun * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Run Forward", false);
            animator.SetBool("Walk Forward", true);
            Vector3 newPosPoint = new Vector3(points[indexCurPoint].position.x, transform.position.y, points[indexCurPoint].position.z);
            transform.LookAt(newPosPoint);
            transform.Translate(Vector3.forward * speedWalk * Time.deltaTime);

            if (Vector3.Distance(transform.position, newPosPoint) < 3)
            {
                indexCurPoint = (indexCurPoint + 1) % points.Count;
            }
        }
    }


    public IEnumerator Reload()
    {
        isReload = true;
        yield return new WaitForSeconds(timeReloadAttack);
        isReload = false;
    }
}
