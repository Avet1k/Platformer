using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AbilityVampirism : MonoBehaviour
{
    [SerializeField] private AreaVampirism _area;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _duration;
    [SerializeField] private float _tickrate;
    [SerializeField] private float _radius;
    [SerializeField] private ContactFilter2D _contactFilter;

    private KeyCode _abilityButton = KeyCode.K;
    private float _currentTimer;
    private float _diameter;

    private void Awake()
    {
        _currentTimer = _cooldown;
        _diameter = _radius * 2;
    }

    private void Update()
    {
        if (_currentTimer < _cooldown)
            _currentTimer += Time.deltaTime;
        
        if (Input.GetKeyDown(_abilityButton) && _currentTimer >= _cooldown)
        {
            var area = Instantiate(_area, transform.position, Quaternion.identity, transform);
            area.transform.localScale *= _diameter;
            area.StartDestroyTimer(_duration);
            _currentTimer = 0;
            
            StartCoroutine(DrainingHealth());
        }
    }

    private IEnumerator DrainingHealth()
    {
        float oneSecond = 1;
        float secondsForOneTick = 1 / _tickrate;
        float totalTicks = _duration / secondsForOneTick;
        var delay = new WaitForSeconds(oneSecond / _tickrate);

        while (totalTicks > 0)
        {
            List<Collider2D> results = new();
            Physics2D.OverlapCircle(transform.position, _radius, _contactFilter, results);

            if (results.Count > 0)
            {
                foreach (var collider in results)
                {
                    collider.TryGetComponent(out Health enemyHealth);
                    enemyHealth.Reduce(_damage);
                    _playerHealth.Add(_damage);
                }
            }

            totalTicks -= 1;
            
            yield return delay;
        }
    }
}
