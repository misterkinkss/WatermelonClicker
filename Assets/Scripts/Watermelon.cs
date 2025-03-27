using System;
using UnityEngine;
using YG;

public class Watermelon : MonoBehaviour
{
    private readonly int _click = Animator.StringToHash("Click");

    public static event Action<double> OnPowerClickChanged;
    
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private Animator animator;
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private ExperienceLevelCounter experienceLevelCounter;
    [SerializeField] private AudioSource audioSource;
    
    private double _multiplier;
    private double _finalClick;
    private double _powerClick;
    
    public double PowerClick
    {
        get => _powerClick;
        set
        {
            _powerClick = value;
            
            OnPowerClickChanged?.Invoke(_powerClick * _multiplier);
        }
    }
    
    private void Awake()
    {
        _multiplier = 1.0D;
        _powerClick = 1.0D;
    }

    public void OnClick()
    {
        scoreCounter.Score += PowerClick * _multiplier;
        
        animator.SetTrigger(_click);

        Vector3 newParticleSystemPosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        newParticleSystemPosition.z = -1;
        particleSystem.transform.position = newParticleSystemPosition;

        particleSystem.Emit(1);

        experienceLevelCounter.Experience++;
        
        audioSource.Play();
    }
    
    private void IncreaseMultiplier()
    {
        _multiplier = 2.0D;
        
        OnPowerClickChanged?.Invoke(_powerClick * _multiplier);
    }

    private void DecreaseMultiplier()
    {
        _multiplier = 1.0D;
        
        OnPowerClickChanged?.Invoke(_powerClick * _multiplier);
    }
    
    private void Save(SavesYG savesYg)
    {
        savesYg.powerClick = PowerClick;
    }

    private void Load(SavesYG savesYg)
    {
        PowerClick = savesYg.powerClick;
    }
    
    private void OnEnable()
    {
        Droplet.OnDropletClicked += IncreaseMultiplier;
        ColorfulScreen.OnBonusEnded += DecreaseMultiplier;
        SaveLoadSystem.LoadRequestEvent += Load;
        SaveLoadSystem.SaveRequestEvent += Save;
    }

    private void OnDisable()
    {
        Droplet.OnDropletClicked -= IncreaseMultiplier;
        ColorfulScreen.OnBonusEnded -= DecreaseMultiplier;
        SaveLoadSystem.LoadRequestEvent -= Load; 
        SaveLoadSystem.SaveRequestEvent -= Save;
    }
}