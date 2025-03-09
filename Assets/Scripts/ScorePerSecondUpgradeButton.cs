using UnityEngine;

public class ScorePerSecondUpgradeButton : ShopButton 
{
    [SerializeField] private ScorePerSecondManager scorePerSecondManager;
    [SerializeField] private double increaseValue;

    public override void Buy()
    {
        if (scoreCounter.GetScore() >= price)
        {
            scoreCounter.RemoveScore(price);
            scorePerSecondManager.AddScorePerSecond(increaseValue);
            price *= 1.2D;
            priceText.text = ScoreFormatter.Format(price);
        }
    }
}
