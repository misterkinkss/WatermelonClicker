using TMPro;
using UnityEngine;

public class ScorePerSecondDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scorePerSecondText;

    private void Start()
    {
        ScorePerSecondManager.OnScorePerSecondChanged += UpdateText;
    }

    private void UpdateText(double score)
    {
        scorePerSecondText.text = ScoreFormatter.Format(score) + "в сек.";
    }
}
