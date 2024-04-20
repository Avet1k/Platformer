using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoints;
    
    public int Points { get; private set; }

    private void Awake()
    {
        Points = _maxPoints;
    }

    public void Add(int points)
    {
        if (points < 0)
            return;
        
        Points = Mathf.Clamp(Points + points, 0, _maxPoints);
    }
    
    public void Reduce(int points)
    {
        if (points < 0)
            return;
        
        Points = Mathf.Clamp(Points - points, 0, _maxPoints);
        
        if (Points <= 0)
            Destroy(gameObject);
    }
}
