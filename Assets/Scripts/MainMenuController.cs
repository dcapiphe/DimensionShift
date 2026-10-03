using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject aboutPanel;

    public void LoadRuins()
    {
        SceneManager.LoadScene("Level1_Ruins");
    }

    public void LoadFactory()
    {
        SceneManager.LoadScene("Level2_Factory");
    }

    public void LoadLaboratory()
    {
        SceneManager.LoadScene("Level3_Laboratory");
    }

    public void ShowAbout()
    {
        if (aboutPanel != null)
            aboutPanel.SetActive(true);
    }

    public void HideAbout()
    {
        if (aboutPanel != null)
            aboutPanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}