using UnityEngine;

[RequireComponent(typeof(Person))]
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
        Points = Mathf.Clamp(Points + points, 0, _maxPoints);
    }
    
    public void Reduce(int points)
    {
        Points -= points;

        if (Points < 0)
            Destroy(gameObject);
    }
}
