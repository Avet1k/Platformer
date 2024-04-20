using UnityEngine;

[RequireComponent(typeof(Collider2D)),
 RequireComponent(typeof(Health))]
public abstract class Person : MonoBehaviour
{ 
    protected Health Health;

    private void Awake()
    {
        Health = GetComponent<Health>();
        OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}
