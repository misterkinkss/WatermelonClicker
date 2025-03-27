using System;
using UnityEngine;
using YG;

public class ExperienceLevelCounter : MonoBehaviour
{
    public static event Action OnLevelChanged;
    
    [SerializeField] private RequiredNextLevelClicksData requiredNextLevelClicksData;
    
    private int _experience;
    private int _level;
    
    public int Level
    {
        get => _level;
        private set
        {
            _level = value;
            
            OnLevelChanged?.Invoke();
        }
    }
    
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
    
    public int MaxLevel => requiredNextLevelClicksData.MaxLevel;

    public int GetCurrentRequiredNextLevelClicks()
    {
        return requiredNextLevelClicksData.RequiredNextLevelClicks[Level];
    }
    
    private void LevelUp()
    {
        Experience = 0;
        Level++;
    }
    
    private void Save(SavesYG savesYg)
    {
        savesYg.level = Level;
        savesYg.experience = Experience;
    }

    private void Load(SavesYG savesYg)
    {
        Level = savesYg.level;
        Experience = savesYg.experience;
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
