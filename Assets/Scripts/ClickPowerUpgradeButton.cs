using UnityEngine;

public class ClickPowerUpgradeButton : ShopButton
{
    [SerializeField] private Watermelon watermelon;
    [SerializeField] private double increaseValue;
    
    public override void Buy()
    {
        if (scoreCounter.Score >= price)
        {
            scoreCounter.Score -= price;
            watermelon.PowerClick += increaseValue;
            price *= 1.5D;
            priceText.text = ScoreFormatter.Format(price);
            
            base.Buy();
        }
    }
}
