using System;
using UnityEngine;

public class ExperienceLevelCounter : MonoBehaviour
{
    public static event Action OnLevelUp;
    
    [SerializeField] private int[] requiredNextLevelClicks;
    
    private int _experience;
    
    public int Level { get; private set; }
    
    public int Experience
    {
        get => _experience;
        set
        {
            _experience = value;

            if (_experience >= requiredNextLevelClicks[Level])
            {
                LevelUp();
            }
        }
    }

    public int GetCurrentRequiredNextLevelClicks()
    {
        return requiredNextLevelClicks[Level];
    }
    
    public int GetLengthRequiredNextLevelClicks()
    {
        return requiredNextLevelClicks.Length;
    }

    private void LevelUp()
    {
        Experience = 0;
        Level++;
        
        OnLevelUp?.Invoke();
    }
}
