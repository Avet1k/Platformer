using UnityEngine;

public abstract class State : MonoBehaviour
{
    private void Awake()
    {
        enabled = false;
        
        OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}
