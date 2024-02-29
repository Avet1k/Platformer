using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectingCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin _))
            Destroy(other.gameObject);
    }
}
