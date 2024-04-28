using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyPatrolState patrolState = new EnemyPatrolState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemySearchState searchState = new EnemySearchState();

    public Transform player;
    public float sightDistance;
    public float wallDistance;
    public float walkSpeed;
    public float runSpeed;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsWall;

    public Vector3 targetPos;
    public float searchCooldown;
    void Start()
    {
        currentState = patrolState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
