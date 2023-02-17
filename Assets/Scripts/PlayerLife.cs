using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; 
    private int Health = 3;
    private int HealthMax = 3;
    private int Life = 5;
    private Animator anim;
    
    [SerializeField] private Text lifeText;
    [SerializeField] private Text healthText;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (Health > 1)
            {
                Health--;
                Damaged();
                healthText.text = "Health: " + Health + "/" + HealthMax;
            }
            else
            {   
                Die();
                Life--;
                lifeText.text = "Life: " + Life;
            }
        }
    }   
    
    private void Damaged()
    {
        anim.SetTrigger("Hurt");
    }
    
    private void Die()
    {
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
