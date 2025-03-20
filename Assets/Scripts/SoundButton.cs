using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Image soundImage;
    [SerializeField] private Sprite enabledSprite; 
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private AudioSource audioSource;

    private bool _isActive;

    private void Start()
    {
        _isActive = true;
    }

    public void OnClick()
    {
        if (_isActive)
        {
            _isActive = false;
            audioMixer.SetFloat("Volume", -80.0f);
            soundImage.sprite = disabledSprite;
        }
        else
        {
            _isActive = true;
            audioMixer.SetFloat("Volume", -10.0f);
            soundImage.sprite = enabledSprite;
            audioSource.Play();
        }
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
}
