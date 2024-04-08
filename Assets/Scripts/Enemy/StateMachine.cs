using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _current;

    private void Start()
    {
        _current.enabled = true;
    }

    public void ChangeState(State newState)
    {
        _current.enabled = false;
        _current = newState;
        _current.enabled = true;
    }
}
