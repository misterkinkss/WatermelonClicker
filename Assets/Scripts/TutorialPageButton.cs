using UnityEngine;

public class TutorialPageButton : MonoBehaviour
{
    public GameObject tutorialPage;

    public void Close()
    {
        tutorialPage.SetActive(false);
    }

    public void Open()
    {
        tutorialPage.SetActive(true);
    }
}
