using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class TutorialPanel : MonoBehaviour
{
    public static event Action<bool> OnTutorialPanelActivitySwitched;
    
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image tutorialPageImage;
    [SerializeField] private Sprite enSprite;
    [SerializeField] private Sprite ruSprite;

    private void Start()
    {
        if (YG2.isFirstGameSession)
        {
            Open();
        }
    }

    public void Open()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(1.0f, 0.2f))
            .AppendCallback(() => canvasGroup.interactable = true)
            .AppendCallback(() => canvasGroup.blocksRaycasts = true)
            .Play();

        OnTutorialPanelActivitySwitched?.Invoke(true);
    }
    
    public void Close()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(0.0f, 0.2f))
            .AppendCallback(() => canvasGroup.interactable = false)
            .AppendCallback(() => canvasGroup.blocksRaycasts = false)
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
        
        OnTutorialPanelActivitySwitched?.Invoke(false);
    }
    
    private void OnLanguageSwitched(string language)
    {
        if (language == "ru")
        {
            tutorialPageImage.sprite = ruSprite;
        }
        else if (language == "en")
        {
            tutorialPageImage.sprite = enSprite;
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