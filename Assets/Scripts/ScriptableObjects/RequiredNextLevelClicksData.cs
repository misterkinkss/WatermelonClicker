using UnityEngine;

[CreateAssetMenu(fileName = "RequiredNextLevelClicksData", menuName = "ScriptableObjects/RequiredNextLevelClicksData", order = -1)]
public class RequiredNextLevelClicksData : ScriptableObject
{
    [SerializeField] private int[] requiredNextLevelClicks;

    public int[] RequiredNextLevelClicks => requiredNextLevelClicks;
    public int MaxLevel => requiredNextLevelClicks.Length;
}