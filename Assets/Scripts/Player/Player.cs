using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
public class Player : Person, IDamagable, IHealable
{
    [SerializeField] private float _cooldown;
    
    private CollectingItems _collectingItems;
    
    public float Cooldown { get; private set; }

    private void OnEnable()
    {
        _collectingItems.CherryPicked += Heal;
    }

    private void OnDisable()
    {
        _collectingItems.CherryPicked -= Heal;
    }

    protected override void OnAwake()
    {
        Cooldown = _cooldown;
        _collectingItems = GetComponent<CollectingItems>();
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
}
