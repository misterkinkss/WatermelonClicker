using TMPro;
using UnityEngine;

public class ScorePerSecondDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scorePerSecondText;
    
    private void UpdateText(double score)
    {
        scorePerSecondText.text = ScoreFormatter.Format(score) + "в сек.";
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
