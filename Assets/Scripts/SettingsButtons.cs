using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    public Animator animator;
    
    private static readonly int CloseSettings = Animator.StringToHash("CloseSettings");
    private static readonly int OpenSettings = Animator.StringToHash("OpenSettings");
    
    public void Open()
    {
        animator.SetTrigger(OpenSettings);
    }
    
    public void Close()
    {
        animator.SetTrigger(CloseSettings);
    }
    
}