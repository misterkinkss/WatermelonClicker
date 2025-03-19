using UnityEngine;
using UnityEngine.Serialization;

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
    }
    
    public void Close()
    {
        animator.SetTrigger(CloseSettings);
        audioSource.Play();
    }
    
}