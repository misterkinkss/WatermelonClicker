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
        WaitForSeconds waitForSeconds = new WaitForSeconds(1.0f);
        while (true)
        {
            scoreCounter.Score += _scorePerSecond;
            yield return waitForSeconds;
        }
    }
}