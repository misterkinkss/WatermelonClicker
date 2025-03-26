using DG.Tweening;
using UnityEngine;
using YG;

public class BonusPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    
    public void Open()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(1.0f, 0.2f))
            .Join(transform.DOScale(1.0f, 0.2f))
            .AppendCallback(() => canvasGroup.interactable = true)
            .AppendCallback(() => canvasGroup.blocksRaycasts = true)
            .Play();
    }
    
    public void Close()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(0.0f, 0.2f))
            .Join(transform.DOScale(0.8f, 0.2f))
            .AppendCallback(() => canvasGroup.interactable = false)
            .AppendCallback(() => canvasGroup.blocksRaycasts = false)
            .Play();
    }

    public void WatchAd()
    {
        YG2.RewardedAdvShow("droplet");
        
        Close();
    }
}

