using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
  public void OnPlayButton()
    {
        //Load Game Scene (Change to whatever the Game Scene is)
        SceneManager.LoadScene(3);
    }

    public void OnOptionButton()
    {
        //Load Options Scene (Change to whatever options scene is)
        SceneManager.LoadScene(1);
    }

    public void OnExitButton()
    {
        //Leaves Game!
        Application.Quit();
    }

    public void OnCreditsButton()
    {
        //Opens Credits Scene (Change to whatever the credits scene is)
        SceneManager.LoadScene(2);
    }

    public void OnBackButton()
    {
        //From Options back to Main Menu
        SceneManager.LoadScene(0);
    }

}
