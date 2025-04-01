using System;
using System.Collections;
using UnityEngine;
using YG;
using Object = UnityEngine.Object;

public class Droplet : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Fall = Animator.StringToHash("Fall");

    public static event Action OnDropletClicked;
    public static event Action OnDropletFalling; 

    [SerializeField] private ColorfulScreen colorfulScreen;
    [SerializeField] private Animator animator;
    [SerializeField] private float fallingDropletCooldown;

    private void Awake()
    {
        StartCoroutine(DropletLaunchCycle());
    }

    private IEnumerator DropletLaunchCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(fallingDropletCooldown);
            
            animator.SetTrigger(Fall);
            
            OnDropletFalling?.Invoke();
        }
    }

    private void OnRewardAdv(string id)
    {
        if (id == "droplet")
        {
            animator.SetTrigger(Fall);
            
            RestartDropletLaunchCycle();
        }
    }
    
    private void RestartDropletLaunchCycle()
    {
        StopCoroutine(DropletLaunchCycle());
        StartCoroutine(DropletLaunchCycle());
    }
    
    public void OnClick()
    {
        animator.SetTrigger(Idle);
        
        StartCoroutine(colorfulScreen.ActiveColorfulScreenBonus());
        
        OnDropletClicked?.Invoke();
    }

    private void OnEnable()
    {
        YG2.onRewardAdv += OnRewardAdv;
    }
    
    private void OnDisable()
    {
        YG2.onRewardAdv -= OnRewardAdv;
    }
}