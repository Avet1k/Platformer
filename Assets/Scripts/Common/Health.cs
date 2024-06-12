using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHeal;
    [SerializeField] private int _damageFromButton;
    [SerializeField] private int _healFromButton;

    public event UnityAction Changed;
    
    [field: SerializeField] public int MaxPoints { get; private set; }
    
    public int Points { get; private set; }

    private void Awake()
    {
        Points = MaxPoints;
    }

    private void OnEnable()
    {
        _buttonDamage.onClick.AddListener(DealDamageFromButton);
        _buttonHeal.onClick.AddListener(HealFromButton);
    }

    private void OnDisable()
    {
        _buttonDamage.onClick.RemoveListener(DealDamageFromButton);
        _buttonHeal.onClick.RemoveListener(HealFromButton);
    }

    public void Add(int points)
    {
        if (points < 0)
            return;
        
        Points = Mathf.Clamp(Points + points, 0, MaxPoints);
        
        Changed?.Invoke();
    }
    
    public void Reduce(int points)
    {
        if (points < 0)
            return;
        
        Points = Mathf.Clamp(Points - points, 0, MaxPoints);
        
        if (Points <= 0)
            Destroy(gameObject);
        
        Changed?.Invoke();
    }

    private void DealDamageFromButton()
    {
        Reduce(_damageFromButton);
    }

    private void HealFromButton()
    {
        Add(_healFromButton);
    }
}
