using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ClickPowerDisplayer : MonoBehaviour
{
    private TMP_Text _clickPowerText;
    
    private void Awake()
    {
        _clickPowerText = GetComponent<TMP_Text>();
    }
    
    private void UpdateText(double clickPower)
    {
        _clickPowerText.text = "+" + ScoreFormatter.Format(clickPower);
    }

    private void OnEnable()
    {
        Watermelon.OnPowerClickChanged += UpdateText;
    }

    private void OnDisable()
    {
        Watermelon.OnPowerClickChanged -= UpdateText;
    }
}
