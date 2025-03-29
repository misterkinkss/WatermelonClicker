using System.Collections;
using UnityEngine;
using YG;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;

    private void Start()
    {
        StartCoroutine(LeaderboardUpdateCycle());
    }

    private IEnumerator LeaderboardUpdateCycle()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3.0f);

        double maxScore = 0.0D;
        
        while (true)
        {
            yield return waitForSeconds;

            if (YG2.isSDKEnabled && scoreCounter.Score > maxScore) 
            {
                YG2.SetLeaderboard("watermelonBoard", (int) maxScore);
                
                maxScore = scoreCounter.Score;
            }
        }
    }
}
