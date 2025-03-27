using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Image soundImage;
    [SerializeField] private Sprite enabledSprite; 
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private AudioSource audioSource;

    private bool _isActive;

    public void OnClick()
    {
        SetState(!_isActive);
        
        audioSource.Play();
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }

    private void SetState(bool activity)
    {
        _isActive = activity;
        audioMixer.SetFloat("Volume", _isActive ? -10.0f : -80.0f);
        soundImage.sprite = _isActive ? enabledSprite : disabledSprite;
    }
    
    private void Save(SavesYG savesYg)
    {
        savesYg.isSoundActive = _isActive;
    }

    private void Load(SavesYG savesYg)
    {
        _isActive = savesYg.isSoundActive;
        
        SetState(_isActive);
    }

    private void OnEnable()
    {
        SaveLoadSystem.LoadRequestEvent += Load;
        SaveLoadSystem.SaveRequestEvent += Save;
    }

    private void OnDisable()
    {
        SaveLoadSystem.LoadRequestEvent -= Load; 
        SaveLoadSystem.SaveRequestEvent -= Save;
    }
}
