using TMPro;

public class ClickPowerUpgradeButton : ShopButton
{
    public TMP_Text particleText;
    public int increaseValue;
    
    public override void Buy()
    {
        if (watermelon.score >= price)
        {
            watermelon.score -= price;
            watermelon.powerClick += increaseValue;
            price = (int)(price * 1.5f);
            priceText.text = price.ToString();
            watermelon.scoreText.text = watermelon.score.ToString();
            particleText.text = "+" + watermelon.powerClick;
            decoration.SetActive(true);
        }
    }
}
