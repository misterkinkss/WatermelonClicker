
public class ScorePerSecondUpgradeButton : ShopButton 
{
    public int increaseValue;
    
    public override void Buy()
    {
        if (watermelon.score >= price)
        {
            watermelon.score -= price;
            watermelon.scorePerSecond += increaseValue;
            watermelon.scoreText.text = watermelon.score.ToString();
            price = (int)(price * 1.5f);
            priceText.text = price.ToString();
            decoration.SetActive(true);
        }
    }
}
