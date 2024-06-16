using UnityEngine;

public abstract class Healthbar : MonoBehaviour
{
    [SerializeField] protected Health PersonHealth;

    private void OnEnable()
    {
        PersonHealth.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        PersonHealth.Changed -= ChangeValue;
    }

    private void Start()
    {
        ChangeValue();
    }

    protected abstract void ChangeValue();
}
