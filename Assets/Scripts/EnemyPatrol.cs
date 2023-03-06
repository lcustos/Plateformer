using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    
    public SpriteRenderer Graphics;
    private Transform target;
    private int destPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            Graphics.flipX = !Graphics.flipX;
        }
    }
}
