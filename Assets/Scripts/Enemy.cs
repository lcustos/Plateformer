using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // référence au joueur
    public float speed = 2f; // vitesse de l'ennemi
    public float attackRange = 1f; // portée d'attaque de l'ennemi
    public int attackDamage = 10; // dégâts infligés à chaque attaque

    private Animator animator; // référence à l'animator de l'ennemi
    private CircleCollider2D attackCollider; // référence au collider d'attaque

    private void Start()
    {
        animator = GetComponent<Animator>(); // récupérer l'animator de l'ennemi
        attackCollider = GetComponent<CircleCollider2D>(); // récupérer le collider d'attaque
    }

    private void Update()
    {
        // Calculer la distance et la direction vers le joueur
        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = (player.position - transform.position).normalized;

        // Faire avancer l'ennemi vers le joueur
        transform.Translate(direction * speed * Time.deltaTime);

        // Si l'ennemi est suffisamment proche, attaquer le joueur
        if (distance < attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("L'ennemi attaque !");
        animator.SetBool("Attack", true); // déclencher l'animation d'attaque

        // Trouver tous les colliders dans la portée d'attaque
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackCollider.radius);

        // Parcourir les colliders touchés
        foreach (Collider2D hitCollider in hitColliders)
        {
            // Si le collider correspond au joueur, appliquer des dégâts
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                // Ajouter ici le code pour infliger des dégâts au joueur
                Debug.Log("L'ennemi inflige des dégâts !");
            }
        }
    }
}
