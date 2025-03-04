using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        ScoreCounter.OnScoreChanged += UpdateText;
    }

    private void UpdateText(double score)
    {
        scoreText.text = ScoreFormatter.Format(score);
    }
}
