using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Search State");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        DetectPlayer(enemy);
        enemy.transform.Rotate(Vector3.up * 1 * Time.deltaTime);
        if (Time.time > enemy.searchCooldown)
        {
            enemy.SwitchState(enemy.patrolState);
        }

    }

    void DetectPlayer(EnemyStateManager enemy)
    {
        for (int i = -10; i <= 10; i++)
        {
            //Player Detection
            var dir2 = Quaternion.Euler(0, i * 9, 0) * enemy.transform.forward;
            if (Physics.Raycast(enemy.transform.position, dir2, enemy.sightDistance, enemy.whatIsPlayer))
            {
                enemy.targetPos = enemy.player.position;
                enemy.SwitchState(enemy.chaseState);
            }
        }
    }
}
