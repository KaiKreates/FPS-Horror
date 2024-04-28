using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Patrol State");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        //Move Forward
        enemy.transform.position += enemy.transform.forward * enemy.walkSpeed * Time.deltaTime;

        
        float delta = 20;
        for (int i = -3; i <= 3; i++)
        {
            //Wall Detection
            var dir = Quaternion.Euler(0, i * delta, 0) * enemy.transform.forward;
            Debug.DrawRay(enemy.transform.position, dir * enemy.wallDistance, Color.green);

            if (Physics.Raycast(enemy.transform.position, dir, enemy.wallDistance, enemy.whatIsWall))
            {
                if (i > 0)
                    enemy.transform.Rotate(Vector3.up * -5);
                else
                    enemy.transform.Rotate(Vector3.up * 5);
            }

            //Player Detection
            var dir2 = Quaternion.Euler(0, i * 10, 0) * enemy.transform.forward;
            if (Physics.Raycast(enemy.transform.position, dir2, enemy.sightDistance, enemy.whatIsPlayer))
            {
                enemy.SwitchState(enemy.chaseState);
            }
        }
    }
}
