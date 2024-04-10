using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
public class Health : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;
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
        _currentHealth = _maxHealth;
        _collectingItems = GetComponent<CollectingItems>();
    }

    private void AddHealthPoints()
    {
        _currentHealth += _healthToAdd;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        
        Debug.Log(_currentHealth);
    }
}
