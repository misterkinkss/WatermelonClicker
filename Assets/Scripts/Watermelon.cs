using UnityEngine;

public class Watermelon : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private Animator animator;
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private ExperienceLevelCounter experienceLevelCounter;
    [SerializeField] private double powerClick;

    private readonly int _click = Animator.StringToHash("Click");

    public void OnClick()
    {
        scoreCounter.Score += powerClick;
        
        animator.SetTrigger(_click);

        Vector3 newParticleSystemPosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        newParticleSystemPosition.z = -1;
        particleSystem.transform.position = newParticleSystemPosition;

        particleSystem.Emit(1);

        experienceLevelCounter.Experience++;
    }

    public double GetPowerClick()
    {
        return powerClick;
    }

    public void AddPowerClick(double value)
    {
        powerClick += value;
    }
}