using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplayer : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    private void UpdateText(double score)
    {
        _scoreText.text = ScoreFormatter.Format(score);
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
