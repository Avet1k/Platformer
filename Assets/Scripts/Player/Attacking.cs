using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attacking : MonoBehaviour
{
    [SerializeField] private Attack _attack;

    private Player _player;
    private float _cooldown;
    private float _currentTimer;
    private float _offset = 2f;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _cooldown = _player.Cooldown;
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
            attack.SetDamage(_player.Damage);
            attack.transform.parent = null;
            _currentTimer = 0;
        }
    }
}
