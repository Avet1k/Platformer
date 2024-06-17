using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mover))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    private static readonly int Fall = Animator.StringToHash(nameof(Fall));
    private static readonly int Jump = Animator.StringToHash(nameof(Jump));

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Mover _mover;
    private float _velocityTolerance = 0.1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.Jumped += PlayJump;
    }

    private void OnDisable()
    {
        _mover.Jumped -= PlayJump;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y < -_velocityTolerance)
            _animator.Play(Fall);

        if (_rigidbody.velocity.y == 0)
        {
            _animator.SetBool(IsGrounded, true);
        }

        if (Math.Abs(_rigidbody.velocity.x) < _velocityTolerance)
        {
            _animator.SetBool(IsRunning, false);
            
            return;
        }
        
        _animator.SetBool(IsRunning, true);
    }

    private void PlayJump()
    {
        _animator.SetBool(IsGrounded, false);
        _animator.Play(Jump);
    }
}
