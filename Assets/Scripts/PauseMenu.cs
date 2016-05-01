using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenuCanvas;

	void Update ()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
	}
    public void Resume()
    {
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("project");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
