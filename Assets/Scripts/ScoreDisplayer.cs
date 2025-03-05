using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void UpdateText(double score)
    {
        scoreText.text = ScoreFormatter.Format(score);
    }
    
    private void OnEnable()
    {
        ScoreCounter.OnScoreChanged += UpdateText;
    }

    private void OnDisable()
    {
        ScoreCounter.OnScoreChanged -= UpdateText;
    }
}
