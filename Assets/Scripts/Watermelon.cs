using System.Collections;
using TMPro;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scorePerSecondText;
    public Animator animator;
    public ParticleSystem particleSystem;
    public double score;
    public double powerClick;
    public double scorePerSecond;
        
    private readonly int _click = Animator.StringToHash("Click");

    private void Start()
    {
        StartCoroutine(PassiveScoreIncome());
    }

    public void OnClick()
    {
        score += powerClick;

        scoreText.text = ScoreFormatter.Format(score);

        animator.SetTrigger(_click);

        Vector3 newParticalSystemPosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        newParticalSystemPosition.z = -1;
        particleSystem.transform.position = newParticalSystemPosition;

        particleSystem.Emit(1);
    }
    
    public IEnumerator PassiveScoreIncome()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1.0f);
        while (true)
        {
            score += scorePerSecond;
            scoreText.text = ScoreFormatter.Format(score);
            yield return waitForSeconds;
        }
    }
}