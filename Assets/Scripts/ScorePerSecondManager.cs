using System;
using System.Collections;
using UnityEngine;

public class ScorePerSecondManager : MonoBehaviour
{
    public static event Action<double> OnScorePerSecondChanged;

    [SerializeField] private ScoreCounter scoreCounter;
    
    private double _scorePerSecond;

    private void Start()
    {
        StartCoroutine(PassiveScoreIncome());
    }
    
    public double ScorePerSecond
    {
        get => _scorePerSecond;
        set
        {
            _scorePerSecond = value;
            
            OnScorePerSecondChanged?.Invoke(_scorePerSecond);
        }
    }
    
    private IEnumerator PassiveScoreIncome()
    {
        while (true)
        {
            scoreCounter.Score = Mathf.Lerp((float) scoreCounter.Score, (float) (scoreCounter.Score + _scorePerSecond), 1.0f * Time.deltaTime);
            yield return null;
        }
    }
}