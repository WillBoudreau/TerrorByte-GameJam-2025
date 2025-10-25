using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class InfoJournalBehaviour : MonoBehaviour
{
    [Header("Info Journal Settings")]
    [SerializeField] private DialogueManager dialogueManager;// Reference to the DialogueManager script
    [SerializeField] private List<TextMeshProUGUI> infoJournalTexts;// List of information journal entries
    [SerializeField] private List<string> evilInfoJournalTexts;// List of evil information journal entries
    [SerializeField] private List<string> goodInfoJournalTexts;// List of good information journal entries
    
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    /// <summary>
    /// Depending on when the threshold value, it determines which info journal text to display.
    /// </summary>
    public void DisplayInfoJournal()
    {
        Debug.Log("Displaying Info Journal Entries.");
        // Determine which info journal text to display based on the current state
        if (dialogueManager.IsEvilPath())
        {
            Debug.Log("Displaying Evil Info Journal Entries.");
            // Display evil info journal texts
            for (int i = 0; i < evilInfoJournalTexts.Count; i++)
            {
                infoJournalTexts[i].text = evilInfoJournalTexts[i];
                Debug.Log("Evil Info Journal Entry: " + evilInfoJournalTexts[i]);
            }
        }
        else if (dialogueManager.IsGoodPath())
        {
            Debug.Log("Displaying Good Info Journal Entries.");
            // Display good info journal texts
            for (int i = 0; i < goodInfoJournalTexts.Count; i++)
            {
                infoJournalTexts[i].text = goodInfoJournalTexts[i];
                Debug.Log("Good Info Journal Entry: " + goodInfoJournalTexts[i]);

            }
        }
        else if(dialogueManager.IsNeutralPath())
        {
            Debug.Log("Displaying Good Info Journal Entries.");
            // Display good info journal texts
            for (int i = 0; i < goodInfoJournalTexts.Count; i++)
            {
                infoJournalTexts[i].text = goodInfoJournalTexts[i];
                Debug.Log("Good Info Journal Entry: " + goodInfoJournalTexts[i]);

            }
        }
    }
}
