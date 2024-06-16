using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event UnityAction Changed;
    
    [field: SerializeField] public int MaxPoints { get; private set; }
    
    public int Points { get; private set; }

    private void Awake()
    {
        Points = MaxPoints;
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
        
        Changed?.Invoke();
    }
}
