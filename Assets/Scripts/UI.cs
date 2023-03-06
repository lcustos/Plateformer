using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    [SerializeField] private Text lifeText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text gemText;



    public int cherryCount;
    public int gemCount;
    public int life = 5;
    public int health = 3;
    public int healthMax = 3;
    
    void Start()
    {
        StartUI();
        DontDestroyOnLoad(gameObject);
    }
    
    
    void Update()
    {
        lifeText.text = "Life remaining: " + life;
        healthText.text = "Health: " + health + "/" + healthMax;
        gemText.text = "Gems: " + gemCount;
        cherriesText.text = "Cherries: " + cherryCount;
    }

    public void StartUI()
    {
    cherryCount = 0;
    gemCount = 0;
    healthMax = 3;
    health = 3;
    }

    public void RestartUI()
    {
        StartUI();
        life--;
    }
}
