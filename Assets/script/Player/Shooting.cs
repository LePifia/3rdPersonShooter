using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] [Range (0.5f, 5f)]float fireRate = 1;

    [SerializeField] int damage = 1;

    private float timer;

    [SerializeField] ParticleSystem shootSmoke;
    [SerializeField] AudioSource gunShootSound;
    private Animator animator;

    [SerializeField] LayerMask shootable;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }


    private void FireGun()
    {
        shootSmoke.Play();
        gunShootSound.Play();
        animator.SetTrigger("Shoot");


        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        if (Physics.Raycast(ray, out hitInfo, 100, shootable))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
