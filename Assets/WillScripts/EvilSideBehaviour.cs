using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class EvilSideBehaviour : MonoBehaviour
{
    [Header("Evil Side Settings")]
    [SerializeField] private List<string> evilResponses;// List of evil dialogue responses
    [SerializeField] private List<string> goodResponses;// List of good dialogue responses
    [SerializeField] private GameObject evilDialoguePanel;// Reference to the evil dialogue panel UI element
    [SerializeField] private DialogueManager dialogueManager;// Reference to the DialogueManager script

    /// <summary>
    /// Displays an evil response based on the morality score.
    /// </summary>
    public void DisplayEvilResponse()
    {
        if(dialogueManager.currentDialogueCount >= dialogueManager.maxDialoguePerDay)
        {
            ShowDialogue("...Go to sleep...");
            return;
        }
        if (dialogueManager.thresholdValue >= dialogueManager.maxThreshold || dialogueManager.thresholdValue >= dialogueManager.neutralThreshold)
        {
            int index = Random.Range(0, goodResponses.Count);
            ShowDialogue(goodResponses[index]);
        }
        else if (dialogueManager.thresholdValue <= dialogueManager.minThreshold || dialogueManager.thresholdValue < dialogueManager.neutralThreshold)
        {
            int index = Random.Range(0, evilResponses.Count);
            ShowDialogue(evilResponses[index]);
        }
    }
    /// <summary>
    /// Shows the dialogue on the evil dialogue panel.
    /// </summary>
    /// <param name="response">The response to display.</param>
    private void ShowDialogue(string response)
    {
        evilDialoguePanel.SetActive(true);
        TextMeshProUGUI dialogueText = evilDialoguePanel.GetComponentInChildren<TextMeshProUGUI>();
        dialogueText.text = response;
    }
}