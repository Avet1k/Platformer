using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
public class Player : Person, IDamagable, IHealable
{
    private CollectingItems _collectingItems;

    private void OnEnable()
    {
        _collectingItems.CherryPicked += Heal;
        Health.OutOfPoints += Die;
    }

    private void OnDisable()
    {
        _collectingItems.CherryPicked -= Heal;
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

    public void Heal(int points)
    {
        Health.Add(points);
    }
    
    protected override void OnAwake()
    {
        _collectingItems = GetComponent<CollectingItems>();
    }
}
