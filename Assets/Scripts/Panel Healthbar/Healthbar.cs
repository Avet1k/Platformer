using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;
    private Health _health;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = _player.GetComponent<Health>();
        
        ChangeValue();
    }

    private void OnEnable()
    {
        _health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeValue;
    }

    private void ChangeValue()
    {
        _slider.maxValue = _health.MaxPoints;
        _slider.value = _health.Points;
    }
}
