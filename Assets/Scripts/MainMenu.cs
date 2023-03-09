using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UI ui;

    public void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
    }

    public void StartNewGame()
    {
       SceneManager.LoadScene("Level0");
    }

    public void Retry()
        {
           SceneManager.LoadScene("Level0");
           ui.life = 5;
        }

    // Fonction appelée lorsque le joueur clique sur le bouton "Quitter"
    public void QuitGame()
    {
        Application.Quit();
    }
}
