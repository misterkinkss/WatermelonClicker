using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopButton : MonoBehaviour
{
    [SerializeField] private ParticleSystem buyParticleSystem;
    [SerializeField] private TMP_Text buyParticleText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image image;
    
    [SerializeField] protected ScoreCounter scoreCounter;
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

    private void OnScoreChanged(double score)
    {
        image.color = score >= price ? Color.white : Color.gray;
    }

    private void OnEnable()
    {
        ScoreCounter.OnScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        ScoreCounter.OnScoreChanged -= OnScoreChanged;
    }
}