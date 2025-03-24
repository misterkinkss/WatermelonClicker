using System.Collections;
using UnityEngine;

public class BonusPanelButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup bonusPanel;
    
    public void CloseBonusPanel()
    {
        StartCoroutine(ClosingBonusPanel());
    }

    private IEnumerator ClosingBonusPanel()
    {
        while (bonusPanel.alpha > 0.0f)
        {
            bonusPanel.alpha -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        bonusPanel.gameObject.SetActive(false);
    }
}
