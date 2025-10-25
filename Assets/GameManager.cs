using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Game Manager Settings")]
    public UIManager uiManager;// Reference to the UIManager script
    public DialogueManager dialogueManager;// Reference to the DialogueManager script
    public InfoJournalBehaviour infoJournalBehaviour;// Reference to the InfoJournalBehaviour script
    public int numOfDaysPassed = 0;// Tracks the number of days passed in the game
    public int maxDays = 7;// Maximum number of days before game over

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        infoJournalBehaviour = FindObjectOfType<InfoJournalBehaviour>();
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
                Debug.Log("Game Over: Evil Path Reached Maximum Days.");
                uiManager.TogglePanel("GameOver");
            }
            else
            {
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
