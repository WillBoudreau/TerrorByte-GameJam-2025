using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Game Manager Settings")]
    public UIManager uiManager;// Reference to the UIManager script
    public DialogueManager dialogueManager;// Reference to the DialogueManager script
    public InfoJournalBehaviour infoJournalBehaviour;// Reference to the InfoJournalBehaviour script
    public InformationPanel informationPanel;// Reference to the InformationPanel script
    public int maxDays = 7;// Maximum number of days before game over
    public int numOfDaysPassed = 0;// Current number of days passed

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        infoJournalBehaviour = FindObjectOfType<InfoJournalBehaviour>();
        informationPanel = FindObjectOfType<InformationPanel>();
    }

    /// <summary>
    /// Advances the game to the next day.
    /// </summary>
    public void AdvanceDay()
    {
        numOfDaysPassed++;
        uiManager.dayCounterText.text = "Day: " + numOfDaysPassed.ToString();
        if (numOfDaysPassed >= maxDays)
        {
            if(dialogueManager.IsEvilPath())
            {
                informationPanel.range = 0.5f;
                Debug.Log("Game Over: Evil Path Reached Maximum Days.");
                uiManager.TogglePanel("GameOver");
            }
            else
            {
                informationPanel.range = 0.5f;
                Debug.Log("Victory: Good Path Reached Maximum Days.");
                uiManager.TogglePanel("Victory");
            }
        }
        else
        {
            Debug.Log("Day " + numOfDaysPassed + " has begun.");
            // Additional logic for starting a new day can be added here
        }
    }
}
