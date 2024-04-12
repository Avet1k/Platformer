using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Person : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _cooldown;

    public int GetHealth() => _health;
    public int GetDamage() => _damage;
    public float GetCooldown() => _cooldown;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
            Destroy(gameObject);
    }
}
