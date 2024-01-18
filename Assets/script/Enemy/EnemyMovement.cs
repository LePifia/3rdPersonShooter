using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private AgroDetection agroDetection;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private float timer;

    private Transform target;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        agroDetection = GetComponent<AgroDetection>();
        agroDetection.OnAggro += AgroDetection_OnAggro;
    }

    private void AgroDetection_OnAggro(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {

        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);

            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }

        if (animator.GetBool("Hitted") == true)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                animator.SetBool("Hitted", false);
                timer = 0;
            }
            
        }


    }
}
