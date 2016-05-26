using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
    
    public Canvas QuitMenu;
    public Button startText;
    public Button exitText;
	//public Button loadText;

	// Use this for initialization
	void Start ()
    {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
		//loadText = loadText.GetComponent<Button> ();
        QuitMenu.enabled = false;
	}
    public void ChooseMode()
    {
        QuitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
    }
    public void exitPress ()
    {
        QuitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
	}
    public void noPress()
    {
        QuitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    
    public void startLevel()
    {
        SceneManager.LoadScene("project");
    }
    public void exitGame()
    {
        Application.Quit();
    }

//	public void loadGame()
//	{
//		SceneManager.LoadScene ("project");
//		SaveAndLoad.Load ();
//	}
}
