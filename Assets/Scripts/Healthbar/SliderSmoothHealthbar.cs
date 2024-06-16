using System.Collections;
using UnityEngine;

public class SliderSmoothHealthbar : SliderHeatlthbar
{
    protected override void ChangeValue()
    {
        StartCoroutine(ChangingValue());
    }

    private IEnumerator ChangingValue()
    {
        bool isChanging = true;
        float origin = SliderHealth.value;
        float target = (float)PersonHealth.Points / PersonHealth.MaxPoints;
        float interpolator = 0;
        float delta = 2;

        while (isChanging)
        {
            yield return new WaitForFixedUpdate();

            SliderHealth.value = Mathf.Lerp(origin, target, interpolator);
            interpolator += delta * Time.deltaTime;

            if (Mathf.Approximately(origin, target))
                isChanging = false;
        }
    }
}
