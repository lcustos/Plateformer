using UnityEngine;

public class WeakSpotBoss : MonoBehaviour
{
    public GameObject objectToDestroy;
    private int hitCount = 0; // Ajoutez un compteur pour garder une trace du nombre de fois où le boss a été touché
    public int requiredHits = 3; // Nombre de coups requis pour détruire le boss

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitCount++; // Incrémentez le compteur de coups lorsque le joueur touche le boss

            if (hitCount >= requiredHits) // Vérifiez si le boss a été touché le nombre requis de fois
            {
                Destroy(objectToDestroy); // Détruisez le boss si le nombre de coups requis a été atteint
            }

            print("touch");
        }
    }
}