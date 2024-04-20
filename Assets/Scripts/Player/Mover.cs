using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const string MovingAxis = "Horizontal";
    private const int HalfTurn = 180;
    
    [SerializeField] private ContactFilter2D _ground;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody2D _rigidbody;
    private float _groundedDistance = 0.1f;

    public event UnityAction Jumped;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movingForward = Input.GetAxis(MovingAxis);

        _rigidbody.velocity = new Vector2(movingForward * _speed, _rigidbody.velocity.y);

        if (movingForward > 0)
            transform.localRotation = Quaternion.identity;
        else if (movingForward < 0)
            transform.localRotation = Quaternion.Euler(0, HalfTurn, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D[] results = new RaycastHit2D[1];

        int hits = _rigidbody.Cast(Vector2.down, _ground, results, _groundedDistance);

        return hits > 0;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpSpeed);
        Jumped?.Invoke();
    }
}
