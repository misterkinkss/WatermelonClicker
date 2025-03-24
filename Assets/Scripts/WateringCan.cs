using System.Collections;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    [SerializeField] private CanvasGroup bonusPanel;
    
    public void OpenBonusPanel()
    {
        StartCoroutine(OpeningBonusPanel());
    }

    private IEnumerator OpeningBonusPanel()
    {
        bonusPanel.gameObject.SetActive(true);
        
        while (bonusPanel.alpha < 1.0f)
        {
            bonusPanel.alpha += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
