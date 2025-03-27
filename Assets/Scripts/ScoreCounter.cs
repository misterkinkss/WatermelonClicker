using System;
using UnityEngine;
using YG;

public class ScoreCounter : MonoBehaviour
{
    public static event Action<double> OnScoreChanged;
    
    private double _score;

    public double Score
    {
        get => _score;
        set
        {
            _score = value;
            
            OnScoreChanged?.Invoke(_score);
        }
    }

    private void Save(SavesYG savesYg)
    {
        savesYg.score = Score;
    }

    private void Load(SavesYG savesYg)
    {
        Score = savesYg.score;
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
