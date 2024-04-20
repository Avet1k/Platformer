using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
public class Player : Person, IDamagable, IHealable
{
    private CollectingItems _collectingItems;

    private void OnEnable()
    {
        _collectingItems.CherryPicked += Heal;
    }

    private void OnDisable()
    {
        _collectingItems.CherryPicked -= Heal;
    }
    
    public void TakeDamage(int damage)
    {
        Health.Reduce(damage);
        Debug.Log("Здоровье игрока уменьшилось до " + Health.Points);
    }

    public void Heal(int points)
    {
        Health.Add(points);
        Debug.Log("Здоровье игрока повысилось до " + Health.Points);
    }
    
    protected override void OnAwake()
    {
        _collectingItems = GetComponent<CollectingItems>();
    }
}
