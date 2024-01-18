using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;

    private int currentHealth;

    [SerializeField] ParticleSystem blood;

    [SerializeField] bool enemy = true;

    private Animator animator;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        Instantiate(blood, new Vector3(transform.position.x, Random.Range(1.15f,2 ), transform.position.z), Quaternion.LookRotation(Vector3.forward, Vector3.back));
        
        if (animator != null)
        {
            animator.SetTrigger("Hitted");
        }


        if (currentHealth <= 0)
        {

            Die();
        }
    }

    private void Die()
    {

        if (enemy == true)
        {
            scoreKeeper.ModifyScore(1);
        }
        

        if(animator == null)
        {
            gameObject.SetActive(false);
        }
        

        if (animator != null)
        {
            Destroy(gameObject, 5f);
            animator.SetTrigger("Dead");
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
