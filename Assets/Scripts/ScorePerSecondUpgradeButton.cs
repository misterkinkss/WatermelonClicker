using UnityEngine;

public class ScorePerSecondUpgradeButton : ShopButton 
{
    [SerializeField] private ScorePerSecondManager scorePerSecondManager;
    [SerializeField] private int increaseValue;

    public override void Buy()
    {
        if (scoreCounter.GetScore() >= price)
        {
            scoreCounter.RemoveScore(price);
            scorePerSecondManager.AddScorePerSecond(increaseValue);
            price *= 1.5D;
            priceText.text = ScoreFormatter.Format(price);
            decoration.SetActive(true);
        }
    }
}
