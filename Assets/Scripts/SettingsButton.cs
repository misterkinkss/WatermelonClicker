using DG.Tweening;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    private static readonly int CloseSettings = Animator.StringToHash("CloseSettings");
    private static readonly int OpenSettings = Animator.StringToHash("OpenSettings");
    
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    
    public void Open()
    {
        animator.SetTrigger(OpenSettings);
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
    
    public void Close()
    {
        animator.SetTrigger(CloseSettings);
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
    
}