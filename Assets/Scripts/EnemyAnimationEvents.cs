using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    public Enemy enemy;

    public void AttackPlayer()
    {
        enemy.AttackPlayer();
    }
}