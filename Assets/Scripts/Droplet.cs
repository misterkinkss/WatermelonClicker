using System;
using System.Collections;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Fall = Animator.StringToHash("Fall");

    public static event Action OnDropletClicked;

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
        }
    }
    
    public void OnClick()
    {
        animator.SetTrigger(Idle);
        StartCoroutine(colorfulScreen.ActiveColorfulScreenBonus());
        
        OnDropletClicked?.Invoke();
    }
}