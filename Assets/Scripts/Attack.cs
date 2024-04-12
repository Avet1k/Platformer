using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Attack : MonoBehaviour
{
    private float _lifetime = 0.2f;
    private int _damage;

    private void Awake()
    {
        Invoke(nameof(SelfDestroy), _lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Debug.Log("Игрок нанес урона: " + _damage);
        }
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
