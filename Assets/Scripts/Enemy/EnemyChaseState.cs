using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Chase State");
        enemy.targetPos = enemy.player.position;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        //Rotate towards target position
        Vector3 lookDir = Vector3.RotateTowards(enemy.transform.forward, enemy.targetPos - enemy.transform.position, 1 * Time.deltaTime, 0);
        Debug.Log("LookDir: " + lookDir);
        enemy.transform.rotation = Quaternion.LookRotation(lookDir);

        //Move Forward
        enemy.transform.position += enemy.transform.forward * enemy.runSpeed * Time.deltaTime;

        if (Mathf.CeilToInt(enemy.targetPos.magnitude) == Mathf.CeilToInt(enemy.transform.position.magnitude))
        {
            enemy.searchCooldown = Time.time + 5;
            enemy.SwitchState(enemy.searchState);
        }
    }
}