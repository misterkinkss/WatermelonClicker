using DG.Tweening;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] private CanvasGroup bonusPanel;
    
    private void OpenBonusPanel()
    {
        bonusPanel.gameObject.SetActive(true);
       
        DOTween.Sequence()
            .Append(bonusPanel.DOFade(1.0f, 0.1f))
            .Play();
    }
}
