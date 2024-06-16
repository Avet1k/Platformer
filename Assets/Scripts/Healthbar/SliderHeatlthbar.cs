using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHeatlthbar : Healthbar
{
    protected Slider SliderHealth;

    private void Awake()
    {
        SliderHealth = GetComponent<Slider>();
    }
    
    protected override void ChangeValue()
    {
        SliderHealth.value = (float)PersonHealth.Points / PersonHealth.MaxPoints;
    }
}
