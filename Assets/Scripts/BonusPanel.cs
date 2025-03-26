using DG.Tweening;
using UnityEngine;

public class BonusPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    
    public void Open()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(1.0f, 0.1f))
            .AppendCallback(() => canvasGroup.interactable = true)
            .AppendCallback(() => canvasGroup.blocksRaycasts = true)
            .Play();
    }
    
    public void Close()
    {
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(0.0f, 0.1f))
            .AppendCallback(() => canvasGroup.interactable = false)
            .AppendCallback(() => canvasGroup.blocksRaycasts = false)
            .Play();
    }
}
