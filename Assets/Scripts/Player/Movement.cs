using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    private static readonly int IsFalling = Animator.StringToHash(nameof(IsFalling));
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _speed = 1;
    private float _jumpForce = 4;
    private int _leftModifier = -1;
    private bool _isFacingRight = true;
    private float _previousPosition;
    private float _currentPosition;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(IsRunning, true);
            
            if (_isFacingRight == false)
                Flip();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * _leftModifier, 0, 0);
            _animator.SetBool(IsRunning, true);

            if (_isFacingRight)
                Flip();
        }
        else if (_animator.GetBool(IsRunning))
        {
            _animator.SetBool(IsRunning, false);
        }

        if (Input.GetKey(KeyCode.Space) && _animator.GetBool(IsGrounded))
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetBool(IsJumping, true);
            _animator.SetBool(IsGrounded, false);
            
            _previousPosition = transform.position.y;
            
            StartCoroutine(CheckFalling());
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (_animator.GetBool(IsGrounded) == false && other.collider.TryGetComponent(out Ground _))
            _animator.SetBool(IsGrounded, true);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Transform sprite = transform;
        
        Vector3 flippedScale = sprite.localScale;
        
        flippedScale.x *= -1;
        sprite.localScale = flippedScale;
    }

    private IEnumerator CheckFalling()
    {
        _currentPosition = transform.position.y;

        yield return _previousPosition > _currentPosition;
        
        _animator.SetBool(IsFalling, true);
        _animator.SetBool(IsJumping, false);

        _previousPosition = _currentPosition;
    }
}
