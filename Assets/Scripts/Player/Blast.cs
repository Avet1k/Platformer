using UnityEngine;

public class Blast : MonoBehaviour
{
    private float _lifetime = 0.2f;

    private void Start()
    {
        Invoke(nameof(SelfDestroy), _lifetime);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
