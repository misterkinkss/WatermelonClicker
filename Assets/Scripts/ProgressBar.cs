using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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

    private void Start()
    {
        StartCoroutine(SmoothIncrease());
    }


    public IEnumerator SmoothIncrease()
    {
        float step = 1.0f / requiredNextLevelClicks[level] / 25.0f;

        while (true)
        {
            if (level == requiredNextLevelClicks.Length) break;
            
            if (fillingImage.fillAmount < (float)experience / requiredNextLevelClicks[level])
            {
                fillingImage.fillAmount += step;
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator SmoothReset()
    {
        while (fillingImage.fillAmount > 0.0f)
        {
            fillingImage.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void UpdateAppearance()
    {
        if (level != requiredNextLevelClicks.Length)
        {
            if (experience >= requiredNextLevelClicks[level])
            {
                experience = 0;
                level += 1;
                levelText.text = "УРОВЕНЬ " + level;
                watermelonImage.sprite = evolutionStageSprites[level];
                
                if (level != requiredNextLevelClicks.Length)
                {
                    StartCoroutine(SmoothReset());
                }
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