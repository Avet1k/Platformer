using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Cherry : MonoBehaviour
{
    [SerializeField] private int _pointsToHeal;

    public int PointsToHeal { get; private set; }

    private void Awake()
    {
        PointsToHeal = _pointsToHeal;
    }
}
