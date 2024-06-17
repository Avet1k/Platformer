using System;

public class Enemy : Person, IDamagable
{
    private void OnEnable()
    {
        Health.OutOfPoints += Die;
    }

    private void OnDisable()
    {
        Health.OutOfPoints -= Die;
    }

    public void TakeDamage(int damage)
    {
        Health.Reduce(damage);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
