using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused {get; private set;}
    public GameObject PausePanel;
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        isPaused = true;
    }

    public void UnpauseGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}