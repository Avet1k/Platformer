using System.Collections;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    [SerializeField] private Cherry _cherry;

    private float _cooldown = 5f;

    private void Start()
    {
        StartCoroutine(SpawnCherry());
    }

    private IEnumerator SpawnCherry()
    {
        var cooldown = new WaitForSeconds(_cooldown);
        bool isWorking = true;
        
        while (isWorking)
        {
            if (transform.childCount == 0)
                Instantiate(_cherry, transform);

            yield return cooldown;
        }
        
        
    }
}
