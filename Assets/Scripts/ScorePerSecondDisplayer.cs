using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(TMP_Text))]
public class ScorePerSecondDisplayer : MonoBehaviour
{
    private TMP_Text _scorePerSecondText;
    private string _textEnding;
    private double _lastScorePerSecond;
    
    private void Awake()
    {
        _scorePerSecondText = GetComponent<TMP_Text>();
    }
    
    private void UpdateText(double scorePerSecond)
    {
        _scorePerSecondText.text = ScoreFormatter.Format(scorePerSecond) + _textEnding;
        
        _lastScorePerSecond = scorePerSecond;
    }
    
    private void OnLanguageSwitched(string language)
    {
        if (language == "ru")
        {
            _textEnding = "в сек.";
        }
        else if (language == "en")
        {
            _textEnding = "per sec.";
        }
        
        UpdateText(_lastScorePerSecond);
    }
    
    private void OnEnable()
    {
        ScorePerSecondManager.OnScorePerSecondChanged += UpdateText;
        YG2.onSwitchLang += OnLanguageSwitched;
    }

    private void OnDisable()
    {
        ScorePerSecondManager.OnScorePerSecondChanged -= UpdateText;
        YG2.onSwitchLang -= OnLanguageSwitched;
    }
}
