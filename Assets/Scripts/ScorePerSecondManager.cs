using System;
using System.Collections;
using UnityEngine;

public class ScorePerSecondManager : MonoBehaviour
{
    public static event Action<double> OnScorePerSecondChanged;

    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private double scorePerSecond;

    private void Start()
    {
        StartCoroutine(PassiveScoreIncome());
    }

    public void AddScorePerSecond(double value)
    {
        scorePerSecond += value;

        OnScorePerSecondChanged?.Invoke(scorePerSecond);
    }

    private IEnumerator PassiveScoreIncome()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1.0f);
        while (true)
        {
            scoreCounter.AddScore(scorePerSecond);
            yield return waitForSeconds;
        }
    }
}