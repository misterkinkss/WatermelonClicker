using DG.Tweening;
using UnityEngine;

public class BonusPanelButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup bonusPanel;
    
    private void CloseBonusPanel()
    {
        DOTween.Sequence()
            .Append(bonusPanel.DOFade(0.0f, 0.1f))
            .Play();
        
        bonusPanel.gameObject.SetActive(false);
    }
}
