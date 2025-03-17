using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Sprite[] evolutionStageSprites;
    [SerializeField] private Image fillingImage;
    [SerializeField] private Image watermelonImage;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private RectTransform watermelonRectTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private ExperienceLevelCounter experienceLevelCounter;

    private readonly int _flash = Animator.StringToHash("Flash");

    private void Update()
    {
        if (experienceLevelCounter.Level != experienceLevelCounter.MaxLevel)
        {
          fillingImage.fillAmount = Mathf.Lerp(fillingImage.fillAmount, (float)experienceLevelCounter.Experience / experienceLevelCounter.GetCurrentRequiredNextLevelClicks(),0.01f);  
        }
    }

    private void UpdateAppearance()
    {
        if (experienceLevelCounter.Level != experienceLevelCounter.MaxLevel)
        {
            levelText.text = "Уровень " + experienceLevelCounter.Level;
            watermelonImage.sprite = evolutionStageSprites[experienceLevelCounter.Level];
            animator.SetTrigger(_flash);
        }
        else
        {
            levelText.text = "Макс. Уровень";
            fillingImage.fillAmount = 1.0f;
            watermelonImage.sprite = evolutionStageSprites[experienceLevelCounter.MaxLevel];
            watermelonRectTransform.sizeDelta = new Vector2(740.5f, 740.5f);
        }
    }

    private void OnEnable()
    {
        ExperienceLevelCounter.OnLevelUp += UpdateAppearance;
    }

    private void OnDisable()
    {
        ExperienceLevelCounter.OnLevelUp -= UpdateAppearance;
    }
}