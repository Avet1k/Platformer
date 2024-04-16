using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
public class Person : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    protected Health Health;
    
    public int Damage { get; private set; }

    private void Awake()
    {
        Damage = _damage;
        Health = GetComponent<Health>();
        OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}
