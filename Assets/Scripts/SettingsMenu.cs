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
}