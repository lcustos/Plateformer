using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    
    private int cherryCount = 0;
    private int gemCount = 0;
    
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text gemText;
	private UI ui;
	[SerializeField] private AudioSource collectionSoundEffect;
    
    
    void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
			//collectionSoundEffect.Play();
            AudioManager.instance.PlaySFX("collect");
            Destroy(collision.gameObject);
            cherryCount++;
            ui.cherryCount = cherryCount;
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
			//collectionSoundEffect.Play();
            AudioManager.instance.PlaySFX("collect");
            Destroy(collision.gameObject);
            gemCount++;
            ui.gemCount = gemCount;
        }
    }
}
