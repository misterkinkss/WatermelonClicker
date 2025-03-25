using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class ShopButton : MonoBehaviour
{
    [SerializeField] protected ParticleSystem buyParticleSystem;
    [SerializeField] protected TMP_Text buyParticleText;
    [SerializeField] protected ScoreCounter scoreCounter;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected double price;
    

    public virtual void Buy()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
        
        audioSource.Play();

        buyParticleText.text = "-" + ScoreFormatter.Format(price);
        buyParticleSystem.Emit(1);
    }
}