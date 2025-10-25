using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;//References the pause menu panel

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void ToggleMenu()
    {
        if (pauseMenu.activeSelf) //if already active
        {
            pauseMenu.SetActive(false);
        }

        else
        {
            pauseMenu.SetActive(true);
        }
    }

    private void Update()
    {
        //if you press the esc key, toggles menu...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }

    }

}
