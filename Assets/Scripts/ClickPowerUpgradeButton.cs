using TMPro;
using UnityEngine;

public class ClickPowerUpgradeButton : ShopButton
{
    [SerializeField] private TMP_Text particleText;
    [SerializeField] private Watermelon watermelon;
    [SerializeField] private double increaseValue;
    
    public override void Buy()
    {
        if (scoreCounter.GetScore() >= price)
        {
            scoreCounter.RemoveScore(price);
            watermelon.AddPowerClick(increaseValue);
            price *= 1.5D;
            priceText.text = ScoreFormatter.Format(price);
            particleText.text = "+" + ScoreFormatter.Format(watermelon.GetPowerClick());
            decoration.SetActive(true);
        }
    }
}
