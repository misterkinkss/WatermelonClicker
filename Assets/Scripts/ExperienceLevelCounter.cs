using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ExperienceLevelCounter : MonoBehaviour
{
    public static event Action OnLevelUp;
    
    [SerializeField] private RequiredNextLevelClicksData requiredNextLevelClicksData;
    
    private int _experience;

    public int MaxLevel => requiredNextLevelClicksData.MaxLevel;
    
    public int Level { get; private set; }
    
    public int Experience
    {
        get => _experience;
        set
        {
            _experience = value;
            
            if (Level == MaxLevel) 
                return;
            
            if (_experience >= requiredNextLevelClicksData.RequiredNextLevelClicks[Level])
            {
                LevelUp();
            }
        }
    }

    public int GetCurrentRequiredNextLevelClicks()
    {
        return requiredNextLevelClicksData.RequiredNextLevelClicks[Level];
    }
    
    private void LevelUp()
    {
        Experience = 0;
        Level++;
        
        OnLevelUp?.Invoke();
    }
}
