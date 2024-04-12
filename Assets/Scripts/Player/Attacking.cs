using UnityEngine;

[RequireComponent(typeof(Person))]
public class Attacking : MonoBehaviour
{
    [SerializeField] private Attack _attack;

    private Person _person;
    private float _cooldown;
    private float _currentTimer;
    private float _offset = 2f;
    
    private void Awake()
    {
        _person = GetComponent<Person>();
        _cooldown = _person.GetCooldown();
        _currentTimer = _cooldown;
    }

    private void Update()
    {
        if (_currentTimer < _cooldown)
            _currentTimer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.J) && _currentTimer >= _cooldown)
        {
            Vector3 attackPosition = transform.position + transform.right * _offset;
            var attack = Instantiate(_attack, attackPosition, Quaternion.identity, transform);
            attack.SetDamage(_person.GetDamage());
            attack.transform.parent = null;
            _currentTimer = 0;
        }
    }
}
