using TMPro;
using UnityEngine;

public class TextHealthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private TMP_Text _label;
    private Health _health;
    
    private void Awake()
    {
        _health = _player.GetComponent<Health>();
        _label = GetComponent<TMP_Text>();
        
        ChangeText();
    }

    private void OnEnable()
    {
        _health.Changed += ChangeText;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeText;
    }

    private void ChangeText()
    {
        int currentHealth = _health.Points;
        int maxHealth = _health.MaxPoints;
        
        _label.text = $"{currentHealth} / {maxHealth}";
    }
}
