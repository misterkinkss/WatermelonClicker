using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    public Animator animator;

    public void OpenSettings()
    {
        animator.SetTrigger("OpeningSettings");
    }
    
    public void CloseSettings()
    {
        animator.SetTrigger("ClosingSettings");
    }
    
}