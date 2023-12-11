using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Movement))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
    private static readonly int IsFalling = Animator.StringToHash(nameof(IsFalling)); 
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Movement _movement;
    private float _velocityTolerance = 0.1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        _movement.Jumped += PlayJump;
    }

    private void OnDisable()
    {
        _movement.Jumped -= PlayJump;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.x < _velocityTolerance
            && _rigidbody.velocity.x > _velocityTolerance * -1)
        {
            _animator.SetBool(IsRunning, false);
            
            return;
        }

        if (_rigidbody.velocity.x > _velocityTolerance)
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }
        
        _animator.SetBool(IsRunning, true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out Ground _) && transform.position.y > other.transform.position.y)
        {
            _animator.SetBool(IsGrounded, true);
        }
    }

    private void PlayJump()
    {
        _animator.SetBool(IsGrounded, false);
        _animator.Play("Jump");
    }
}
