using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _isRunning = "isRunning";
    private float _speed = 2;
    private int _leftModifier = -1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(_isRunning, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * _leftModifier, 0, 0);
            _animator.SetBool(_isRunning, true);
        }
        else if (_animator.GetBool(_isRunning))
        {
            _animator.SetBool(_isRunning, false);
        }
        
    }
}
