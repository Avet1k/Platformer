using UnityEngine;

[RequireComponent(typeof(CollectingItems))]
public class Player : Person
{
    public float Cooldown { get; private set; }
}
