using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Manager Settings")]
    public GameObject dialoguePanel;// Reference to the dialogue panel UI element
    public GameObject evilDialoguePanel;// Reference to the evil dialogue panel UI element
    public GameObject infoPanel;// Reference to the info panel UI element
    public GameObject gameplayHUD;// Reference to the gameplay HUD UI element
    public GameObject victoryPanel;// Reference to the victory panel UI element
    public GameObject gameOverPanel;// Reference to the game over panel UI element
    public TextMeshProUGUI dayCounterText;// Reference to the day counter text UI element

    private void Start()
    {
        dayCounterText.text = "Day: 0";
        CloseAllPanels();
        gameplayHUD.SetActive(true);
    }
    /// <summary>
    /// Closes all UI panels.
    /// </summary>
    public void CloseAllPanels()
    {
        dialoguePanel.SetActive(false);
        evilDialoguePanel.SetActive(false);
        infoPanel.SetActive(false);
        gameplayHUD.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    /// <summary>
    /// Toggles UI panels based on the provided panel name.
    /// </summary>
    public void TogglePanel(string panelName)
    {
        CloseAllPanels();
        switch (panelName)
        {
            case "EvilDialogue":
                dialoguePanel.SetActive(true);
                evilDialoguePanel.SetActive(true);
                break;
            case "Info":
                infoPanel.SetActive(true);
                break;
            case "GameplayHUD":
                gameplayHUD.SetActive(true);
                break;
            case "Victory":
                victoryPanel.SetActive(true);
                break;
            case "GameOver":
                gameOverPanel.SetActive(true);
                break;
            default:
                Debug.LogWarning("Panel name not recognized: " + panelName);
                break;
        }
    }
}
