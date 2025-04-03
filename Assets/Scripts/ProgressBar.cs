using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Sprite[] evolutionStageSprites;
    [SerializeField] private Image fillingImage;
    [SerializeField] private Image watermelonImage;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private RectTransform watermelonRectTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private ExperienceLevelCounter experienceLevelCounter;
    [SerializeField] private AudioSource audioSource;

    private readonly int _flash = Animator.StringToHash("Flash");

    private void Update()
    {
        if (experienceLevelCounter.Level != experienceLevelCounter.MaxLevel)
        {
          fillingImage.fillAmount = Mathf.Lerp(fillingImage.fillAmount, (float)experienceLevelCounter.Experience / experienceLevelCounter.GetCurrentRequiredNextLevelClicks(),10.0f * Time.deltaTime);  
        }
    }

    private void OnLevelChanged()
    {
        if (experienceLevelCounter.Level != experienceLevelCounter.MaxLevel)
        {
            watermelonImage.sprite = evolutionStageSprites[experienceLevelCounter.Level];
        }
        else
        {
            fillingImage.fillAmount = 1.0f;
            watermelonImage.sprite = evolutionStageSprites[experienceLevelCounter.MaxLevel];
            watermelonRectTransform.sizeDelta = new Vector2(740.5f, 740.5f);
        }

        if (experienceLevelCounter.Level != 0)
        {
            animator.SetTrigger(_flash);
            audioSource.Play();
        }
        
        UpdateText(YG2.lang);
    }

    private void UpdateText(string language)
    {
        if (experienceLevelCounter.Level != experienceLevelCounter.MaxLevel)
        {
            if (language == "ru")
            {
                levelText.text = "Уровень " + experienceLevelCounter.Level;
            }
            else if (language == "en")
            {
                levelText.text = "Level " + experienceLevelCounter.Level;
            }
        }
        else
        {
            if (language == "ru")
            {
                levelText.text = "Макс. Уровень";
            }
            else if (language == "en")
            {
                levelText.text = "Max. Level";
            }
        }
    }
    
    private void OnEnable()
    {
        ExperienceLevelCounter.OnLevelChanged += OnLevelChanged;
        YG2.onSwitchLang += UpdateText;
    }

    private void OnDisable()
    {
        ExperienceLevelCounter.OnLevelChanged -= OnLevelChanged;
        YG2.onSwitchLang -= UpdateText;
    }
}