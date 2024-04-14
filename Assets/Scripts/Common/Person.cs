using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
public class Person : MonoBehaviour
{
    private Health _health;
    
    public int Damage { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage(int damage)
    {
        _health.ReduceHealthPoints(damage);
    }
}
