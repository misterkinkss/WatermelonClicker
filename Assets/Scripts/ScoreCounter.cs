using System;
using UnityEngine;

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
}
