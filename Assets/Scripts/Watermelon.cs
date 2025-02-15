using TMPro;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator animator;
    public ParticleSystem particleSystem;
    public int score;
    public int powerClick;
    

    public int Click = Animator.StringToHash("Click");


    public void OnClick()
    {
        score += powerClick;

        scoreText.text = score.ToString();

        animator.SetTrigger(Click);

        Vector3 newParticalSystemPosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        newParticalSystemPosition.z = -1;
        particleSystem.transform.position = newParticalSystemPosition;

        particleSystem.Emit(1);
    }
}