using DG.Tweening;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private SettingsPanel settingsPanel;
    [SerializeField] private AudioSource audioSource;
    
    public void OpenSettingsPanel()
    {
        settingsPanel.OpenAnimation();
        
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
    
    public void CloseSettingsPanel()
    {
        settingsPanel.CloseAnimation();
        
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
    
}