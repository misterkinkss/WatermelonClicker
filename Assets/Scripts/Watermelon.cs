using System.Collections;
using TMPro;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator animator;
    public ParticleSystem particleSystem;
    public int score;
    public int powerClick;
    public int scorePerSecond;
        
    private readonly int _click = Animator.StringToHash("Click");

    private void Start()
    {
        StartCoroutine(PassiveScoreIncome());
    }

    public void OnClick()
    {
        score += powerClick;

        scoreText.text = score.ToString();

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
            scoreText.text = score.ToString();
            yield return waitForSeconds;
        }
    }
}