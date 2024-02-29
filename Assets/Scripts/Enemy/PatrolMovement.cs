using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint;
    private float _speed = 1f;
    private bool _isFacingRight = false;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position,
            _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
            
            Flip();
        }
    }
    
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Transform sprite = transform;
        
        Vector3 flippedScale = sprite.localScale;
        
        flippedScale.x *= -1;
        sprite.localScale = flippedScale;
    }
}
