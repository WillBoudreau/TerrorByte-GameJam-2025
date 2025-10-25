using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class InfoJournalBehaviour : MonoBehaviour
{
    [Header("Info Journal Settings")]
    [SerializeField] private DialogueManager dialogueManager;// Reference to the DialogueManager script
    [SerializeField] private List<TextMeshProUGUI> infoJournalTexts;// List of information journal entries
    [SerializeField] private List<string> evilInfoJournalTexts;// List of evil information journal entries
    [SerializeField] private List<string> goodInfoJournalTexts;// List of good information journal entries
    
    /// <summary>
    /// Depending on when the threshold value, it determines which info journal text to display.
    /// </summary>
    public void DisplayInfoJournal()
    {
        // Determine which info journal text to display based on the current state
        if (dialogueManager.IsEvilPath())
        {
            // Display evil info journal texts
            for(int i = 0; i < evilInfoJournalTexts.Count; i++)
            {
                Debug.Log("Evil Info Journal Entry: " + evilInfoJournalTexts[i]);
                infoJournalTexts[i].text = evilInfoJournalTexts[i];
            }
        }
        else if (dialogueManager.IsGoodPath() || dialogueManager.thresholdValue ==  dialogueManager.neutralThreshold)
        {
            // Display good info journal texts
            for(int i = 0; i < goodInfoJournalTexts.Count; i++)
            {
                Debug.Log("Good Info Journal Entry: " + goodInfoJournalTexts[i]);
                infoJournalTexts[i].text = goodInfoJournalTexts[i];
            }
        }
        else
        {
            // Display regular info journal texts
            foreach (TextMeshProUGUI text in infoJournalTexts)
            {
                Debug.Log("Info Journal Entry: " + text.text);
            }
        }
    }
}
