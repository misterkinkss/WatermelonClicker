using System;
using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(TMP_Text))]
public class TextLanguageSetter : MonoBehaviour
{
    [SerializeField] private string ruText;
    [SerializeField] private string enText;

    private TMP_Text _text;
    
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnLanguageSwitched(string language)
    {
        if (language == "ru")
        {
            _text.text = ruText;
        }
        else if (language == "en")
        {
            _text.text = enText;
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
