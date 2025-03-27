using System;
using System.Collections;
using UnityEngine;
using YG;

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
    
    private void Save(SavesYG savesYg)
    {
        savesYg.scorePerSecond = ScorePerSecond;
    }

    private void Load(SavesYG savesYg)
    {
        ScorePerSecond = savesYg.scorePerSecond;
    }

    private void OnEnable()
    {
        SaveLoadSystem.LoadRequestEvent += Load;
        SaveLoadSystem.SaveRequestEvent += Save;
    }

    private void OnDisable()
    {
        SaveLoadSystem.LoadRequestEvent -= Load; 
        SaveLoadSystem.SaveRequestEvent -= Save;
    }
}