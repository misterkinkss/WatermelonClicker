using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite enSprite;
    [SerializeField] private Sprite ruSprite;
    
    public void OnClick()
    {
        if (YG2.lang == "ru")
        {
            YG2.SwitchLanguage("en");
                    
            image.sprite = enSprite;
        }
        else
        {
            YG2.SwitchLanguage("ru");
                    
            image.sprite = ruSprite;
        }
        
        DOTween.Sequence()
            .Append(transform.DOScale(0.9f, 0.15f))
            .Append(transform.DOScale(1.0f, 0.15f))
            .Play();
    }
}
