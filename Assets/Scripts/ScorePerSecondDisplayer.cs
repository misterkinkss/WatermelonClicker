using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScorePerSecondDisplayer : MonoBehaviour
{
    private TMP_Text _scorePerSecondText;
    
    private void Awake()
    {
        _scorePerSecondText = GetComponent<TMP_Text>();
    }
    
    private void UpdateText(double score)
    {
        _scorePerSecondText.text = ScoreFormatter.Format(score) + "в сек.";
    }

    private void OnEnable()
    {
        ScorePerSecondManager.OnScorePerSecondChanged += UpdateText;
    }

    private void OnDisable()
    {
        ScorePerSecondManager.OnScorePerSecondChanged -= UpdateText;
    }
}
