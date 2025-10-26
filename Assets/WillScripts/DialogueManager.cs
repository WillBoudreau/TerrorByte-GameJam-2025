using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Corruption Settings")]
    [SerializeField] private CorruptionSpread corruptionManager;// Reference to the CorruptionManager script
    [Header("Dialogue Settings")]
    public float thresholdValue;// Morality score threshold to determine good or bad dialogue
    public float thresholdIncrement = 0.5f;// Morality score threshold to determine good or bad dialogue
    public float maxThreshold = 10f;// Maximum morality score
    public float goodThreshold = 5f;// Good morality score
    public float neutralThreshold = 0f;// Neutral morality score
    public float badThreshold = -5f;// Bad morality score
    public float minThreshold = -10f;// Minimum morality score
    public int maxDialoguePerDay = 3;// Maximum number of dialogues per day
    public int currentDialogueCount = 0;// Current number of dialogues that have occurred today
    [SerializeField] private float typingSpeed = 0.05f;// Speed of the typing effect
    [SerializeField] private GameObject sleepButton;// Reference to the sleep button UI element
    [Header("Dialogue Manager Lines")]
    [SerializeField] private TextMeshProUGUI dialogueText;// Reference to the dialogue text UI element
    public GameObject dialoguePanel;// Reference to the dialogue panel UI element
    [SerializeField] private string[] currentDialogueLine = new string[4];// Current dialogue line being displayed
    [SerializeField] private List<string> greatDialogueLines;// List of dialogue lines for great morality
    [SerializeField] private List<string> neutralDialogueLines;// List of dialogue lines for neutral morality
    [SerializeField] private List<string> goodDialogueLines;// List of dialogue lines for good morality
    [SerializeField] private List<string> badDialogueLines;// List of dialogue lines for bad morality
    [Header("Dialogue Choices/Texts")]
    [SerializeField] private List<TextMeshProUGUI> dialogueChoicesTexts;// List of dialogue choice text UI elements
    [Header("Morality object References")]
    [SerializeField] private List<GameObject> moralityObjects;// List of morality-related game objects
    private void Start()
    {
        sleepButton.SetActive(false);


        corruptionManager = FindObjectOfType<CorruptionSpread>();
        dialoguePanel.SetActive(false);
        SetDialogueChoicesText();
    }
    #region Determine Dialogue Lines
    /// <summary>
    /// Determines the dialogue lines based on the morality score.
    /// </summary>
    private void DetermineDialogueLines()
    {
        if (thresholdValue >= maxThreshold)
        {
            thresholdValue = maxThreshold;
        }
        else if (thresholdValue >= goodThreshold && thresholdValue < maxThreshold)
        {
            Debug.Log("Good Threshold Reached");
            for (int i = 0; i < currentDialogueLine.Length; i++)
            {
                if (i == 0)
                {
                    currentDialogueLine[i] = greatDialogueLines[0];
                }
                else if (i == 1)
                {
                    currentDialogueLine[i] = greatDialogueLines[1];
                }
                else if (i == 2)
                {
                    currentDialogueLine[i] = goodDialogueLines[2];
                }
                else if (i == 3)
                {
                    currentDialogueLine[i] = neutralDialogueLines[0];
                }
            }
        }
        else if (thresholdValue < goodThreshold && thresholdValue > neutralThreshold)
        {
            Debug.Log("Good to Neutral Threshold Reached");
            for (int i = 0; i < currentDialogueLine.Length; i++)
            {
                if (i == 0)
                {
                    if(currentDialogueLine[i] == greatDialogueLines[0])
                    {
                        currentDialogueLine[i] = goodDialogueLines[1];
                    }
                    else
                    {
                        currentDialogueLine[i] = goodDialogueLines[0];
                    }
                }
                else if (i == 1)
                {
                    if(currentDialogueLine[i] == greatDialogueLines[1])
                    {
                        currentDialogueLine[i] = goodDialogueLines[2];
                    }
                    else
                    {
                        currentDialogueLine[i] = goodDialogueLines[1];
                    }
                }
                else if (i == 2)
                {
                    if(currentDialogueLine[i] == goodDialogueLines[2])
                    {
                        currentDialogueLine[i] = neutralDialogueLines[0];
                    }
                    else
                    {
                        currentDialogueLine[i] = goodDialogueLines[2];
                    }
                }
                else if (i == 3)
                {
                    if(currentDialogueLine[i] == neutralDialogueLines[0])
                    {
                        currentDialogueLine[i] = neutralDialogueLines[1];
                    }
                    else
                    {
                        currentDialogueLine[i] = neutralDialogueLines[0];
                    }
                }
            }
        }
        else if (thresholdValue == neutralThreshold)
        {
            Debug.Log("Neutral Threshold Reached");
            for (int i = 0; i < currentDialogueLine.Length; i++)
            {
                if (i == 0)
                {
                    currentDialogueLine[i] = goodDialogueLines[3];
                }
                else if (i == 1)
                {
                    currentDialogueLine[i] = neutralDialogueLines[1];
                }
                else if (i == 2)
                {
                    currentDialogueLine[i] = neutralDialogueLines[2];
                }
                else if (i == 3)
                {
                    currentDialogueLine[i] = badDialogueLines[3];
                }
            }
        }
        else if (thresholdValue < neutralThreshold && thresholdValue > badThreshold)
        {
            for (int i = 0; i < currentDialogueLine.Length; i++)
            {
                if (i == 0)
                {
                    currentDialogueLine[i] = goodDialogueLines[0];
                }
                else if (i == 1)
                {
                    currentDialogueLine[i] = neutralDialogueLines[0];
                }
                else if (i == 2)
                {
                    currentDialogueLine[i] = badDialogueLines[1];
                }
                else if (i == 3)
                {
                    currentDialogueLine[i] = badDialogueLines[2];
                }
            }
        }
        else if (thresholdValue <= badThreshold && thresholdValue > minThreshold)
        {
            for (int i = 0; i < currentDialogueLine.Length; i++)
            {
                if (i == 0)
                {
                    currentDialogueLine[i] = neutralDialogueLines[0];
                }
                else if (i == 1)
                {
                    currentDialogueLine[i] = neutralDialogueLines[1];
                }
                else if (i == 2)
                {
                    currentDialogueLine[i] = badDialogueLines[2];
                }
                else if (i == 3)
                {
                    currentDialogueLine[i] = badDialogueLines[3];
                }
            }
        }
        else if (thresholdValue <= minThreshold)
        {
            thresholdValue = minThreshold;
        }
    }
    /// <summary>
    /// Sets the dialogue choices text based on the current dialogue lines.
    /// </summary>
    private void SetDialogueChoicesText()
    {
        Debug.Log("Setting dialogue choices text with threshold value: " + thresholdValue);
        foreach (var dialogueChoiceText in dialogueChoicesTexts)
        {
            dialogueChoiceText.text = "";
        }
        DetermineDialogueLines();
        for (int i = 0; i < dialogueChoicesTexts.Count; i++)
        {
            if(currentDialogueCount >= maxDialoguePerDay || currentDialogueCount == maxDialoguePerDay - 1)
            {
                dialogueChoicesTexts[i].text = "Sleep...";
                sleepButton.SetActive(true);
                continue;
            }
            Debug.Log("Setting dialogue choice text for index: " + i);
            dialogueChoicesTexts[i].text = currentDialogueLine[i];
        }
    }
    /// <summary>
    /// When the player hits a dialogue choice, determine whether it was a good or bad choice and adjust the morality score accordingly.
    /// </summary>
    public void OnDialogueChoice(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= currentDialogueLine.Length)
            return;
        else if (currentDialogueCount >= maxDialoguePerDay)
            SetDialogueChoicesText();
        else
        {
            string chosenLine = currentDialogueLine[choiceIndex];

            SetDialogueChoicesText();

            if (goodDialogueLines.Contains(chosenLine))
            {
                thresholdValue += thresholdIncrement;
            }
            else if (badDialogueLines.Contains(chosenLine))
            {
                thresholdValue -= thresholdIncrement;
                corruptionManager.SpreadCorruption();
            }
            else if (neutralDialogueLines.Contains(chosenLine))
            {
                thresholdIncrement += 0f;
            }
            else if(greatDialogueLines.Contains(chosenLine))
            {
                thresholdValue += thresholdIncrement * 2;
            }
            else if (choiceIndex == 10)
            {
                Debug.Log("Special dialogue choice selected.");
                StartCoroutine(PlayExitDialogueLine());
            }

            OnDialogueTrigger();
            currentDialogueCount++;
            UpdateMoralityObjects(thresholdValue);
        }
    }
    #endregion
    #region Path Checkers
    /// <summary>
    /// When a dialogue is triggered, open the dialogue panel.
    /// </summary>
    public void OnDialogueTrigger()
    {
        dialoguePanel.SetActive(true);
    }
    /// <summary>
    /// Checks if the current path is evil based on the morality score.
    /// </summary>
    public bool IsEvilPath()
    {
        Debug.Log("Checking Evil Path with threshold value: " + thresholdValue);
        Debug.Log("Evil Path Check Result: " + (thresholdValue <= badThreshold));
        return thresholdValue <= badThreshold || thresholdValue < neutralThreshold;
    }
    /// <summary>
    /// Checks if the current path is good based on the morality score.
    /// </summary>
    public bool IsGoodPath()
    {
        return thresholdValue >= goodThreshold || thresholdValue > neutralThreshold;
    }
    /// <summary>
    /// Checks if the current path is neutral based on the morality score.
    /// </summary>
    public bool IsNeutralPath()
    {
        return thresholdValue == neutralThreshold;
    }
    #endregion
    /// <summary>
    /// Influence the morality score directly, positive values for good, negative for bad.
    /// Have the dialogue manager adjust the dialogue choices accordingly.
    /// </summary>
    public void InfluenceMorality(float amount)
    {
        thresholdValue += amount;
        Debug.Log("Morality influenced by: " + amount + ", new threshold value: " + thresholdValue);
        SetDialogueChoicesText();
    }
    /// <summary>
    /// Play a specific dialogue line
    /// </summary>
    private IEnumerator PlayExitDialogueLine()
    {
        dialogueText.text = "I'm always going to be here...";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "";
    }
    /// <summary>
    /// Reset the dialogue count at the start of a new day.
    /// and set the sleep button to inactive.
    /// </summary>
    public void ResetDialogueCount()
    {
        currentDialogueCount = 0;
        SetDialogueChoicesText();
        sleepButton.SetActive(false);
    }
    #region Morality Objects Management
    /// <summary>
    /// Have the morality objects update their state based on the current morality path.
    /// </summary>
    public void UpdateMoralityObjects(float moralityScore)
    {
        foreach(var obj in moralityObjects)
        {
            InteractableOBJ interactable = obj.GetComponent<InteractableOBJ>();
            if(interactable == null)
            {
                Debug.LogWarning("Morality object does not have an InteractableOBJ component.");
                interactable = FindObjectOfType<InteractableOBJ>();
            }
        }
        if(moralityScore < neutralThreshold)
        {
            foreach(var obj in moralityObjects)
            {
                InteractableOBJ interactable = obj.GetComponent<InteractableOBJ>();
                if(interactable != null)
                {
                    interactable.SetToEvil();
                }
            }
        }
        else if(moralityScore > neutralThreshold)
        {
            foreach (var obj in moralityObjects)
            {
                InteractableOBJ interactable = obj.GetComponent<InteractableOBJ>();
                if (interactable != null)
                {
                    interactable.SetToInfo();
                }
            }
        }
    }
    #endregion
}