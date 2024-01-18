using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private AgroDetection agroDetection;
    private Health healthTarget;

    [SerializeField] float attackRefreshRate = 1.5f;
    [SerializeField] AudioSource gunShootSound;
    private float attackTimer;
    private Animator animator;

    private void Awake()
    {
        agroDetection = GetComponent<AgroDetection>();
        agroDetection.OnAggro += AgroDetection_OnAggro;
        animator = GetComponentInChildren<Animator>();
    }

    private void AgroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;

            if (CanAttack())
            {
                Attack();
            }
        }
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0;
        gunShootSound.Play();
        animator.SetTrigger("Shoot");
        healthTarget.TakeDamage(1);
    }

}
