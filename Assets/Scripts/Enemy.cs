using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 1f;

    private Transform player;
    private Animator animator;
    private bool facingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>(); // récupérer l'animator de l'ennemi
        player = GameObject.FindGameObjectWithTag("Player").transform; // récupérer la position du joueur
    }

    private void Update()
    {
        // Calculer la distance et la direction vers le joueur
        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = (player.position - transform.position).normalized;

        // Si l'ennemi est suffisamment proche, attaquer le joueur
        if (distance < attackRange)
        {
            animator.SetTrigger("BossAttack");

            // Ajouter ici le code pour infliger des dégâts au joueur
            Debug.Log("L'ennemi inflige des dégâts !");
        }
        else
        {
                    animator.ResetTrigger("BossAttack");
                    animator.SetBool("BossIdle", false);
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

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si le joueur entre dans la zone de détection de l'ennemi, le suivre
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Le joueur a été détecté !");
        }
    }
}
