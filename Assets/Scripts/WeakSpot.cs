using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
