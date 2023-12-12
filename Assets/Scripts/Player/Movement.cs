using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _ground;
    
    private Rigidbody2D _rigidbody;
    private float _speed = 2;
    private float _jumpSpeed = 7;
    private float _groundedDistance = 0.1f;

    public event UnityAction Jumped;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();
    }

    private void FixedUpdate()
    {
        float movingForward = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(movingForward * _speed, _rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] grounds = new RaycastHit2D[1];

        int hits = _rigidbody.Cast(Vector2.down, _ground, grounds, _groundedDistance);

        return hits > 0;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpSpeed);
        Jumped?.Invoke();
    }
}
