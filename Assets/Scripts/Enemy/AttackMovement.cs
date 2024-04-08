using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class AttackMovement : State
{
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
        _enemyMovement = GetComponent<EnemyMovement>();
        _target = transform;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
