using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
[RequireComponent(typeof(Player))]
public class PlayerHealth : Health
{
    private int _maxHealth;
    private int _healthToAdd = 20;
    private CollectingItems _collectingItems;

    private void OnEnable()
    {
        _collectingItems.CherryPicked += AddHealthPoints;
    }

    private void OnDisable()
    {
        _collectingItems.CherryPicked -= AddHealthPoints;
    }

    private void Awake()
    {
        _maxHealth = HealthPoints;
        _collectingItems = GetComponent<CollectingItems>();
    }

    private void AddHealthPoints()
    {
        HealthPoints = Mathf.Clamp(HealthPoints + _healthToAdd, 0, _maxHealth);
    }
}
