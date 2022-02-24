using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    GameObject PausePanel;
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void UnpauseGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
