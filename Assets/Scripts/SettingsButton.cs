using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    private static readonly int CloseSettings = Animator.StringToHash("CloseSettings");
    private static readonly int OpenSettings = Animator.StringToHash("OpenSettings");
    
    public Animator animator;
    
    public void Open()
    {
        animator.SetTrigger(OpenSettings);
    }
    
    public void Close()
    {
        animator.SetTrigger(CloseSettings);
    }
    
}