using TMPro;
using UnityEngine;
using YG;

public class FlexibleTextLanguageSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private string ruText;
    [SerializeField] private string enText;
    
    private void OnLanguageSwitched(string language)
    {
        if (language == "ru")
        {
            text.text = ruText;
        }
        else if (language == "en")
        {
            text.text = enText;
        }
    }
    
    private void OnEnable()
    {
        YG2.onSwitchLang += OnLanguageSwitched;
    }
    
    private void OnDisable()
    {
        YG2.onSwitchLang -= OnLanguageSwitched;
    }
}
