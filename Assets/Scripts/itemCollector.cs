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

	[SerializeField] private AudioSource collectionSoundEffect;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
			collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherryCount++;
            cherriesText.text = "Cherries: " + cherryCount;
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
			collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gemCount++;
            gemText.text = "Gems: " + gemCount;
        }
    }
}
