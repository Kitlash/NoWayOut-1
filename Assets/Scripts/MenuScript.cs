using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
    
    public Canvas QuitMenu;
    public Canvas chooseMode;
    public Canvas soloCanvas;
    public Button playText;
    public Button startText;
    public Button exitText;
    public Canvas Settings;
    public Canvas LanguageCan;
    public AudioSource mabite;
	//public Button loadText;

	// Use this for initialization
	void Start ()
    {
        chooseMode = chooseMode.GetComponent<Canvas>();
        playText = playText.GetComponent<Button>();
        soloCanvas = soloCanvas.GetComponent<Canvas>();
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        //loadText = loadText.GetComponent<Button> ();
        Settings = Settings.GetComponent<Canvas>();
        LanguageCan = LanguageCan.GetComponent<Canvas>();
        QuitMenu.enabled = false;
        chooseMode.enabled = false;
        soloCanvas.enabled = false;
        Settings.enabled = false;
        //LanguageCan.enabled = false;
		LanguageCan.enabled = false;
        mabite.enabled = false;
    }
    public void ChooseMode() // Choose mode menu
    {
        mabite.enabled = true;
        mabite.Play();
        chooseMode.enabled = true;
        playText.enabled = false;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = false;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }

    public void back1() // back to Start menu 
    {
        chooseMode.enabled = false;
        playText.enabled = true;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = true;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }
    public void soloCan()
    {
        mabite.Play();
        chooseMode.enabled = false;
        playText.enabled = false;
        soloCanvas.enabled = true;
        QuitMenu.enabled = false;
        exitText.enabled = false;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }
    public void back2()
    {
        chooseMode.enabled = true;
        playText.enabled = false;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = false;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }
    public void exitPress () // Quit menu
    {
        mabite.Play();
        chooseMode.enabled = false;
        playText.enabled = false;
        soloCanvas.enabled = false;
        QuitMenu.enabled = true;
        exitText.enabled = false;
        Settings.enabled = false;
    }
    public void noPress() // Start menu
    {
        chooseMode.enabled = false;
        playText.enabled = true;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = true;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }
    public void SettingsCan()
    {
        mabite.enabled = true;
        mabite.Play();
        chooseMode.enabled = false;
        playText.enabled = false;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = false;
        Settings.enabled = true;
        LanguageCan.enabled = false;
    }
    public void LangCan()
    {   
        chooseMode.enabled = false;
        playText.enabled = false;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = false;
        Settings.enabled = true;
        LanguageCan.enabled = true;
    }
    public void back3()
    {
        chooseMode.enabled = false;
        playText.enabled = true;
        soloCanvas.enabled = false;
        QuitMenu.enabled = false;
        exitText.enabled = true;
        Settings.enabled = false;
        LanguageCan.enabled = false;
    }
    public void startLevel() // new Canvas -> Button New Game
    {
        mabite.Play();
        SceneManager.LoadScene("project");
    }
    public void startMulti() // Button multi
    {
        mabite.Play();
        SceneManager.LoadScene("multiPlayer");
    }
    public void exitGame() // QuitGame -> Button Yes
    {
        Application.Quit();
    }
    public void French()
    {
        SceneManager.LoadScene("frenchMenu");
    }
    public void English()
    {
        SceneManager.LoadScene("Menu");
    }

//	public void loadGame()
//	{
//		SceneManager.LoadScene ("project");
//		SaveAndLoad.Load ();
//	}
}
