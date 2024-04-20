using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class PatrolState : State
{
    [SerializeField] private Transform _path;

    private EnemyMover _enemyMover;
    private Transform _target;
    private Transform[] _points;
    private int _currentPoint;
    private float _speed = 1f;

    private void OnEnable()
    {
        _enemyMover.SetTarget(_target);
        _enemyMover.SetSpeed(_speed);
    }

    private void Update()
    {
        if (transform.position == _target.position)
        {
            _currentPoint = ++_currentPoint % _points.Length;
            _target = _points[_currentPoint];
            _enemyMover.SetTarget(_target);
        }
    }
    
    protected override void OnAwake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);

        _target = _points[_currentPoint];
    }
}
