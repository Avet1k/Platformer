using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class AttackState : State
{
    [SerializeField] private int Damage;
    
    private EnemyMover _enemyMover;
    private Transform _target;
    private float _speed = 3f;

    private void OnEnable()
    {
        _enemyMover.SetTarget(_target);
        _enemyMover.SetSpeed(_speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    protected override void OnAwake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _target = transform;
    }
}
