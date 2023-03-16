using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public int touchDamage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(touchDamage);
            }
        }
    }
}