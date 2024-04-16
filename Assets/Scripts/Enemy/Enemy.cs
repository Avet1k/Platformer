public class Enemy : Person, IDamagable
{
    public void TakeDamage(int damage)
    {
        Health.Reduce(damage);
    }
}
