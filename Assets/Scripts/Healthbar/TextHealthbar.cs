using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthbar : Healthbar
{
    private TMP_Text _label;

    private void Awake()
    {
        _label = GetComponent<TMP_Text>();
    }

    protected override void ChangeValue()
    {
        _label.text = $"{PersonHealth.Points} / {PersonHealth.MaxPoints}";
    }
}
