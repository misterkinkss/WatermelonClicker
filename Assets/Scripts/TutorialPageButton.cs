using UnityEngine;

public class TutorialPageButton : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPage;
    [SerializeField] private AudioSource audioSource;

    public void Close()
    {
        tutorialPage.SetActive(false);
        
        audioSource.Play();
    }

    public void Open()
    {
        tutorialPage.SetActive(true);
        
        audioSource.Play();
    }
}
