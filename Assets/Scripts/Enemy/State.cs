using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    protected StateMachine Machine { get; private set; }
    
    private void Awake()
    {
        enabled = false;
        Machine = GetComponent<StateMachine>();
        
        OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}
