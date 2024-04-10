using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollectingItems : MonoBehaviour
{
    public event UnityAction CherryPicked;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin _))
        {
            Destroy(other.gameObject);
        }
        else if (other.TryGetComponent(out Cherry _))
        {
            CherryPicked?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
