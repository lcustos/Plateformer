using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Nom de la scène de jeu
    public string gameSceneName = "Level1";

    // Fonction appelée lorsque le joueur clique sur le bouton "Nouvelle partie"
    public void StartNewGame()
    {
       SceneManager.LoadScene(gameSceneName);
    }

    // Fonction appelée lorsque le joueur clique sur le bouton "Quitter"
    public void QuitGame()
    {
        Application.Quit();
    }
}