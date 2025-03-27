using System;
using System.Collections;
using UnityEngine;
using YG;

public class SaveLoadSystem : MonoBehaviour
{
    public static event Action<SavesYG> LoadRequestEvent;
    public static event Action<SavesYG> SaveRequestEvent;
    
    private void Start()
    {
        LoadRequestEvent?.Invoke(YG2.saves);
        StartCoroutine(SaveCycle());
    }

    private IEnumerator SaveCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            
            SaveRequestEvent?.Invoke(YG2.saves);
            
            YG2.SaveProgress();
        }
    }
}