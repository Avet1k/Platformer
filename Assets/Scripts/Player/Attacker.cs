using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Blast _blast;
    [SerializeField] private int _damage;
    [SerializeField] private float _size;
    [SerializeField] private float _cooldown;
    [SerializeField] private LayerMask _layerMask;
    
    private float _currentTimer;
    private float _offset = 2f;
    
    private void Awake()
    {
        _currentTimer = _cooldown;
    }

    private void Update()
    {
        if (_currentTimer < _cooldown)
            _currentTimer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.J) && _currentTimer >= _cooldown)
        {
            Vector3 attackPosition = transform.position + transform.right * _offset;
            var blast = Instantiate(_blast, attackPosition, Quaternion.identity, transform);
            blast.transform.parent = null;
            _currentTimer = 0;
            DealDamage(attackPosition);
        }
    }
    
    private void DealDamage(Vector3 position)
    {
        var result = Physics2D.OverlapCircle(position, _size, _layerMask);

        if (result is not null && result.transform.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Debug.Log("Игрок нанес урона: " + _damage);
        }
    }
}
