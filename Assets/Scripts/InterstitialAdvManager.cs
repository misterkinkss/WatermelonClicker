using System.Collections;
using UnityEngine;
using YG;

public class InterstitialAdvManager : MonoBehaviour
{
    [SerializeField] private TimerBeforeAdv timerBeforeAdv;
    [SerializeField] private int advDelay;
    
    private WaitForSeconds _interstitialAdvDelay;
        
    private bool _isAdvCanShown;
    
    private void Start()
    {
        _isAdvCanShown = true;
        
        _interstitialAdvDelay = new WaitForSeconds(advDelay);
        
        StartCoroutine(InterstitialAdvTimerCycle());
    }

    private IEnumerator InterstitialAdvTimerCycle()
    {
        while (true)
        {
            yield return _interstitialAdvDelay;
            
            if (_isAdvCanShown)
            {
                YG2.PauseGame(true);
                
                yield return timerBeforeAdv.StartCountdown();
                
                YG2.InterstitialAdvShow();
                
                YG2.PauseGame(false);
            }
        }
    }

    private void OnModalWindowActivitySwitched(bool activity)
    {
        _isAdvCanShown = !activity;
    }
    
    private void OnEnable()
    {
        BonusPanel.OnPanelActivitySwitched += OnModalWindowActivitySwitched;
        TutorialPanel.OnTutorialPanelActivitySwitched += OnModalWindowActivitySwitched;
    }

    private void OnDisable()
    {
        BonusPanel.OnPanelActivitySwitched -= OnModalWindowActivitySwitched;
        TutorialPanel.OnTutorialPanelActivitySwitched -= OnModalWindowActivitySwitched;
    }
}