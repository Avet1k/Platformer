using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private bool _isFacingRight;
    private Transform _target;
    private float _speed;
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position,
            _speed * Time.deltaTime);

        if (_isFacingRight && transform.position.x > _target.position.x)
        {
            _isFacingRight = false;
            Flip();
        }
        else if (_isFacingRight == false && transform.position.x < _target.position.x)
        {
            _isFacingRight = true;
            Flip();
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Flip()
    {
        int halfTurn = 180;
        
        transform.localRotation *= Quaternion.Euler(0, halfTurn, 0);
    }
}
