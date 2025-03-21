using UnityEngine;

public class ScorePerSecondUpgradeButton : ShopButton 
{
    [SerializeField] private ScorePerSecondManager scorePerSecondManager;
    [SerializeField] private double increaseValue;

    public override void Buy()
    {
        if (scoreCounter.Score >= price)
        {
            scoreCounter.Score -= price;
            scorePerSecondManager.ScorePerSecond += increaseValue;
            
            base.Buy();
        }
    }
}
