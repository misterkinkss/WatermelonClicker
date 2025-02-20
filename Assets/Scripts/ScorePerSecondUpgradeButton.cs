
public class ScorePerSecondUpgradeButton : ShopButton 
{
    public int increaseValue;
    
    public override void Buy()
    {
        if (watermelon.score >= price)
        {
            watermelon.score -= price;
            watermelon.scorePerSecond += increaseValue;
            watermelon.scorePerSecondText.text = ScoreFormatter.Format(watermelon.scorePerSecond) + "в сек.";
            watermelon.scoreText.text = ScoreFormatter.Format(watermelon.score);
            price *= 1.5D;
            priceText.text = ScoreFormatter.Format(price);
            decoration.SetActive(true);
        }
    }
}
