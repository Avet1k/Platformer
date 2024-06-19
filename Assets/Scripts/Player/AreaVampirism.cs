using System.Collections;
using UnityEngine;

public class AreaVampirism : MonoBehaviour
{
    public void StartDestroyTimer(float lifetime)
    {
        StartCoroutine(SelfDestroy(lifetime));
    }

    private IEnumerator SelfDestroy(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        
        Destroy(gameObject);
    }
}
