using UnityEngine;

[RequireComponent(typeof(PatrolState)),
 RequireComponent(typeof(AttackState)),
 RequireComponent(typeof(StateMachine))]
public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _player;
    [SerializeField] private EnemyBody _enemyBody;
    
    private bool _isDetected;
    private float _viewDistance = 4f;
    private PatrolState _patrolState;
    private AttackState _attackState;
    private StateMachine _stateMachine;

    private void Awake()
    {
        _patrolState = GetComponent<PatrolState>();
        _attackState = GetComponent<AttackState>();
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        RaycastHit2D[] results = new RaycastHit2D[1];
        
        int hits = Physics2D.Raycast(_enemyBody.transform.position, -_enemyBody.transform.right,
            _player, results, _viewDistance);

        if (_isDetected == false && hits > 0)
        {
            _isDetected = true;
            _attackState.SetTarget(results[0].transform);
            _stateMachine.ChangeState(_attackState);
        }
        else if (_isDetected && hits == 0)
        {
            _isDetected = false;
            _stateMachine.ChangeState(_patrolState);
        }
    }
}
