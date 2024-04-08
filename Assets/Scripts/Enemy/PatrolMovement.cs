using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class PatrolMovement : State
{
    [SerializeField] private Transform _path;

    private EnemyMovement _enemyMovement;
    private Transform _target;
    private Transform[] _points;
    private int _currentPoint;
    private float _speed = 1f;

    private void OnEnable()
    {
        _enemyMovement.SetTarget(_target);
        _enemyMovement.SetSpeed(_speed);
    }

    protected override void OnAwake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);

        _target = _points[_currentPoint];
    }

    private void Update()
    {
        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            _target = _points[_currentPoint];
            _enemyMovement.SetTarget(_target);
        }
    }
    
    
}
