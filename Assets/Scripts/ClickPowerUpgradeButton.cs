using TMPro;

public class ClickPowerUpgradeButton : ShopButton
{
    public TMP_Text particleText;
    public double increaseValue;
    
    public override void Buy()
    {
        if (watermelon.score >= price)
        {
            watermelon.score -= price;
            watermelon.powerClick += increaseValue;
            price *= 1.5D;
            priceText.text = ScoreFormatter.Format(price);
            watermelon.scoreText.text = ScoreFormatter.Format(watermelon.score);
            particleText.text = "+" + ScoreFormatter.Format(watermelon.powerClick);
            decoration.SetActive(true);
        }
    }
}
