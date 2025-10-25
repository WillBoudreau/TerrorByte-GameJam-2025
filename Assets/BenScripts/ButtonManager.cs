using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject optionsMenu;//panel for options
    public GameObject creditsMenu;//panel for credits
    public GameObject controlsMenu;//panel for controls
    public GameObject pauseMenu;//panel for pause menu (in game)

    private void Start()
    {
        ClearMenus();
    }

    public void ClearMenus()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OnPlayButton()
    {
        //Load Game Scene (Change to whatever the Game Scene is)
        SceneManager.LoadScene(1);
    }

    public void OnOptionButton()
    {
        //Opens Options Panel
        ClearMenus();
        optionsMenu.SetActive(true);
    }

    public void OnExitButton()
    {
        //Leaves Game!
        Application.Quit();
    }

    public void OnCreditsButton()
    {
        //Opens Credits Panel 
        ClearMenus();
        creditsMenu.SetActive(true);
    }

    public void OnControlsButton()
    {
        //Opens Controls Panel
        ClearMenus();
        controlsMenu.SetActive(true);
    }

    public void OnBackButton()
    {
        //Close panel
        ClearMenus();
    }

    public void OnQuitButton()
    {
        //returns to main menu (from game)
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
    }

    public void OnProgressButton()
    {
        //Progresses from Day scene to night scene

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Game(Day)")
        {
            SceneManager.LoadScene(2);
        }

        else
        {
            SceneManager.LoadScene(1);
        }
        
    }

}
