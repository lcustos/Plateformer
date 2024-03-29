using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D _rb;
    public int health = 3;
    private Animator _anim;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;
	private UI ui;    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ui = GameObject.Find("UI").GetComponent<UI>();

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (health > 1)
            {
                health--;
                Damaged();
                ui.health = health;
				print("health: " + health);
				print("UI health: " + ui.health);
            }
            else
            {   
                Die();
            }
        }
		if (collision.gameObject.CompareTag("Eagle"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (health > 1)
            {
                health--;
                Damaged();
                ui.health = health;
            }
            else
            {   
                Die();
            }
        }
    }   
    
    private void Damaged()
    {
        //damageSoundEffect.Play();
        AudioManager.instance.PlaySFX("damage");
        _anim.SetTrigger("Hurt");
    }
    
    private void Die()
    {
        //deathSoundEffect.Play();
        AudioManager.instance.PlaySFX("death");
        _anim.SetTrigger("Death");
        _rb.bodyType = RigidbodyType2D.Static;
 		ui.RestartUI();

       if (ui.life > 0) {
                 Invoke("RestartLevel", 2f); 
       }
        else
        {
               SceneManager.LoadScene("MenuGameOver");
        }

    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void TakeDamage(int damage)
    {
        if (health > damage)
        {
            health -= damage;
            Damaged();
            ui.health = health;
        }
        else
        {
            Die();
        }
    }

}
