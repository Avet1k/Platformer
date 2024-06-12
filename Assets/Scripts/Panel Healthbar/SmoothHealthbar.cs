using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;
    private Health _health;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = _player.GetComponent<Health>();
        
        ChangeValue();
    }

    private void OnEnable()
    {
        _health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeValue;
    }

    private void ChangeValue()
    {
        _slider.maxValue = _health.MaxPoints;
        
        StartCoroutine(Changing());
    }

    private IEnumerator Changing()
    {
        bool isChanging = true;
        var delay = new WaitForFixedUpdate();
        float maxDelta = 2;
        
        while (isChanging)
        {
            yield return delay;

            _slider.value = Mathf.MoveTowards(_slider.value, _health.Points, maxDelta);

            if (Mathf.Approximately(_slider.value, _health.Points))
                isChanging = false;
        }
    }
}
