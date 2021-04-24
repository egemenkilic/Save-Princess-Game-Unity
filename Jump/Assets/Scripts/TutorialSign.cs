using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    public GameObject tutorialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorialText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorialText.SetActive(false);
    }
}
