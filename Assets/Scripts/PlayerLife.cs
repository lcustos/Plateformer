using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; 
    public int Health = 3;
    public int HealthMax = 3;
    public int Life = 5;
    private Animator anim;
    
    [SerializeField] private Text lifeText;
    [SerializeField] private Text healthText;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;
    public static PlayerLife instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Health = HealthMax;
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
		if (collision.gameObject.CompareTag("Eagle"))
        	{
            	Die();
        	}
    }   
    
    private void Damaged()
    {
        damageSoundEffect.Play();
        anim.SetTrigger("Hurt");
    }
    
    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;

       if (Life > 0)
            {
                SceneManager.LoadScene("MenuGameOver");
            }
            else
            {
                Invoke("RestartLevel", 2f);
            }

    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
