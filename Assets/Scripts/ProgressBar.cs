using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image fillingImage;
    public Image watermelonImage;
    public TMP_Text levelText;
    public RectTransform watermelonRectTransform;
    public Sprite[] evolutionStageSprites;
    public int[] requiredNextLevelClicks;
    public int level;
    public int experience;

    public void IncreaseFilling()
    {
        if (level != requiredNextLevelClicks.Length)
        {
            fillingImage.fillAmount += 1.0f / requiredNextLevelClicks[level]; 

            if (experience >= requiredNextLevelClicks[level])
            {
                experience = 0;
                level += 1;
                levelText.text = "УРОВЕНЬ " + level;
                fillingImage.fillAmount = 0.0f;
                watermelonImage.sprite = evolutionStageSprites[level];
            }
        }

        if (level == requiredNextLevelClicks.Length)
        {
            levelText.text = "МАКС. УРОВЕНЬ";
            fillingImage.fillAmount = 1.0f;
            watermelonRectTransform.sizeDelta = new Vector2(740.5f, 740.5f);
        }
    }
}