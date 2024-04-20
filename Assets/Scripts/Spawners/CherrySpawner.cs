using System.Collections;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    [SerializeField] private Cherry _cherry;
    [SerializeField] private ContactFilter2D _ground;

    private int _minX = -8;
    private int _maxX = 8;
    private int _minY = -1;
    private int _maxY = 1;
    private float _cooldown = 2f;

    private void Start()
    {
        StartCoroutine(SpawnCherry());
    }

    private IEnumerator SpawnCherry()
    {
        var cooldown = new WaitForSeconds(_cooldown);
        bool isWorking = true;
        float distance = 3f;
        float offset = 0.5f;
        RaycastHit2D[] results = new RaycastHit2D[1];
        
        while (isWorking)
        {
            if (transform.childCount == 0)
            {
                var rayX = Random.Range(_minX, _maxX + 1);
                var rayY = Random.Range(_minY, _maxY + 1);
                Vector3 origin = new Vector3(rayX, rayY, transform.position.z);
    
                var hit = Physics2D.Raycast(origin, Vector3.down, _ground, results, distance);
                Vector3 groundPosition = results[0].point;
                Vector3 position = new Vector3(groundPosition.x, groundPosition.y + offset, groundPosition.z);
                
                Instantiate(_cherry, position, Quaternion.identity, transform);
            }

            yield return cooldown;
        }
    }
}
