using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static event Action<double> OnScoreChanged;
    
    [SerializeField] private double score;
    
    public double GetScore()
    {
        return score;
    }
    
    public void AddScore(double value)
    {
        score += value;
        
        OnScoreChanged.Invoke(score);
    }

    public void RemoveScore(double value)
    {
        score -= value;
        
        OnScoreChanged.Invoke(score);
    }
}
