using UnityEngine;

public class TutorialPageCloseButton : MonoBehaviour
{
    public GameObject tutorialPage;

    public void OnClick()
    {
        tutorialPage.SetActive(false);
    }
}
