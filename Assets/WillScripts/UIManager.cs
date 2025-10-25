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
    public GameObject mainMenuPanel;// Reference to the main menu panel UI element
    public GameObject pauseMenuPanel;//Reference to the pause menu panel UI element
    public TextMeshProUGUI dayCounterText;// Reference to the day counter text UI element
    [Header("Info Object Panel")]
    public GameObject infoObjectPanel;// Reference to the info object panel UI element
    public TextMeshProUGUI infoObjectNameText;// Reference to the info object name text UI element
    public TextMeshProUGUI infoObjectDescriptionText;// Reference to the info object description text UI element
    [Header("Class References")]
    [SerializeField] private InformationPanel informationPanel;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private EvilSideBehaviour evilSideBehaviour;
    private void Start()
    {
        informationPanel = FindObjectOfType<InformationPanel>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        evilSideBehaviour = FindObjectOfType<EvilSideBehaviour>();
        
        dayCounterText.text = "Day: 0";
        CloseAllPanels();
        mainMenuPanel.SetActive(true);
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
        infoObjectPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
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
                // Show the evil dialogue panel
                dialoguePanel.SetActive(true);
                evilDialoguePanel.SetActive(true);

                // Trigger the evil side behaviour to display a response
                evilSideBehaviour.DisplayEvilResponse();

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
            case "InfoObject":
                infoObjectPanel.SetActive(true);
                break;
            case "MainMenu":
                mainMenuPanel.SetActive(true);
                break;
            default:
                Debug.LogWarning("Panel name not recognized: " + panelName);
                break;
        }
    }
}
