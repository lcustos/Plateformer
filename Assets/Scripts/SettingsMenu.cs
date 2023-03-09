using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu; // référence au menu de paramètres

    public void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true); // activer l'affichage du menu de paramètres
        Canvas.ForceUpdateCanvases(); // forcer la mise à jour de la toile de l'interface utilisateur
    }

    public void HideSettingsMenu()
    {
        settingsMenu.SetActive(false); // désactiver l'affichage du menu de paramètres
    }
    // faire démarrer le jeu sans la pause
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    // press any keybord key to hide settings menu
    void Update()
    {
        if (Input.anyKey)
        {
            HideSettingsMenu();
        }
    }
    // when the settings menu is open the game is paused
    void OnEnable()
    {
        if (settingsMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
    }
    // when the settings menu is closed the game is unpaused
    private void OnDisable()
         {
             Time.timeScale = 1;
         }
}