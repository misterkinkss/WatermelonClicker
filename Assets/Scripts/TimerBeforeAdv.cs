using System.Collections;
using UnityEngine;

public class TimerBeforeAdv : MonoBehaviour
{
    [SerializeField] private GameObject[] countdownGameObjects;
    [SerializeField] private CanvasGroup canvasGroup;

    public Coroutine StartCountdown()
    {
        return StartCoroutine(Countdown());
    }
    
    private IEnumerator Countdown()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        
        for (int i = 0; i <= countdownGameObjects.Length; i++)
        {
            if (i != 0)
            {
                countdownGameObjects[i - 1].SetActive(false);
            }
            countdownGameObjects[i].SetActive(true);
            
            yield return new WaitForSecondsRealtime(1.0f);
            
            if (i == countdownGameObjects.Length - 1)
            {
                canvasGroup.alpha = 0.0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                
                countdownGameObjects[i].SetActive(false);
                
                yield break;
            }
        }
    }
}
