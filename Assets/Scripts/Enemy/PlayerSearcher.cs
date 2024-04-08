using UnityEngine;

[RequireComponent(typeof(PatrolMovement))]
[RequireComponent(typeof(AttackMovement))]
[RequireComponent(typeof(StateMachine))]
public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _player;
    
    private bool _isDetected;
    private float _viewDistance = 4f;
    private PatrolMovement _patrolMovement;
    private AttackMovement _attackMovement;
    private StateMachine _stateMachine;

    private void Awake()
    {
        _patrolMovement = GetComponent<PatrolMovement>();
        _attackMovement = GetComponent<AttackMovement>();
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        RaycastHit2D[] results = new RaycastHit2D[1];
        
        int hits = Physics2D.Raycast(transform.position, -transform.right, _player, results, 
            _viewDistance);

        if (_isDetected == false && hits > 0)
        {
            _isDetected = true;
            _attackMovement.SetTarget(results[0].transform);
            _stateMachine.ChangeState(_attackMovement);
        }
        else if (_isDetected && hits == 0)
        {
            _isDetected = false;
            _stateMachine.ChangeState(_patrolMovement);
        }
    }
}
