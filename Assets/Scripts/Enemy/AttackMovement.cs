using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(EnemyMovement))]
public class AttackMovement : State
{
    private Enemy _enemy;
    private EnemyMovement _enemyMovement;
    private Transform _target;
    private float _speed = 3f;

    private void OnEnable()
    {
        _enemyMovement.SetTarget(_target);
        _enemyMovement.SetSpeed(_speed);
    }

    protected override void OnAwake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _target = transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Player player))
        {
            player.TakeDamage(_enemy.Damage);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
