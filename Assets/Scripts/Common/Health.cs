using UnityEngine;

[RequireComponent(typeof(Person))]
public class Health : MonoBehaviour
{
    public int HealthPoints { get; protected set; }

    public void ReduceHealthPoints(int damage)
    {
        HealthPoints -= damage;

        if (HealthPoints < 0)
            Destroy(gameObject);
    }
}
