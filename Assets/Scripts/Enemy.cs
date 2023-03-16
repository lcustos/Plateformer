using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public int damage = 10;
    public float aggroRange = 5f;

    private Transform player;
    private Animator animator;
    private bool facingRight = true;
    private bool inAggroRange = false;
    private float lastAttackTime;
    
    public int maxHits = 3;
    private int currentHits = 0;
    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {   
        if (isDead) return;
        
        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = (player.position - transform.position).normalized;
    
        if (distance <= aggroRange)
        {
            inAggroRange = true;
        }
        else
        {
            inAggroRange = false;
        }
    
        if (inAggroRange)
        {
            if (distance < attackRange)
            {
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    animator.SetTrigger("BossAttack");
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                animator.SetBool("InRange", false);
                animator.SetBool("BossWalk", true);
    
                if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }
                else if (direction.x < 0 && facingRight)
                {
                    Flip();
                }
    
                transform.Translate(direction.x * speed * Time.deltaTime * Vector3.right);
            }
        }
        else
        {
            animator.SetBool("BossWalk", false);
        }
    }
    public void TakeHit()
    {
        if (!isDead)
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void AttackPlayer()
    {
        Debug.Log("L'ennemi inflige des dégâts !");
        // Call the TakeDamage method from the PlayerLife script to apply damage
        player.GetComponent<PlayerLife>().TakeDamage(damage);
    }
	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player is above the boss
            if (collision.transform.position.y > transform.position.y + GetComponent<Collider2D>().bounds.extents.y)
            {
                // The player jumped on the weakpoint, so don't deal damage.
            }
            else
            {
                // The player didn't jump on the weakpoint, so deal damage.
                collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
            }
        }
    }

}
