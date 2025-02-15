using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Watermelon watermelon;
    public int price;
    public TMP_Text priceText;
    public TMP_Text particleText;
    public TMP_Text clickPowerText;
    public GameObject decoration;

    public void OnClick()
    {
        if (watermelon.score >= price)
        {
            watermelon.score -= price;
            watermelon.powerClick += 1;
            price = (int) (price * 1.5f);
            priceText.text = price.ToString();
            watermelon.scoreText.text = watermelon.score.ToString();
            particleText.text = "+" + watermelon.powerClick;
            clickPowerText.text = "+" + watermelon.powerClick;
            decoration.SetActive(true);
        }
        
    }
    
}
