using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InteractableOBJ : MonoBehaviour
{
    public enum ObjectType
    {
        Info,
        Evil
    }
    public ObjectType objectType;// Type of the interactable object
    [SerializeField] private UIManager uiManager;
    [SerializeField] private DialogueManager dialogueManager;

    [Header("Interactable Object Settings")]
    public string objectName;// Name of the interactable object
    [SerializeField] private List<string> objectDescriptions;// Descriptions for the interactable object
    [SerializeField] private List<string> goodObjectDescriptions;// Descriptions for good interactable objects
    [SerializeField] private List<string> evilObjectDescriptions;// Descriptions for evil interactable objects
    public Material highlightMaterial;// Material used for highlighting the object
    public Material originalMaterial;// Original material of the object
    public Material evilMaterial;// Material used for evil objects

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        SetMaterial();
    }

    /// <summary>
    /// Interact with the object
    /// </summary>
    public void Interact()
    {
        switch (objectType)
        {
            case ObjectType.Info:
                uiManager.infoObjectNameText.text = objectName;
                if (objectName == "pic")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[0] + " " + goodObjectDescriptions[0];
                }
                else if (objectName == "diary")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[1] + " " + goodObjectDescriptions[1];
                }
                else if (objectName == "toy")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[2] + " " + goodObjectDescriptions[2];
                }
                uiManager.TogglePanel("InfoObject");
                dialogueManager.InfluenceMorality(1f);
                break;
            case ObjectType.Evil:
                UpdateObjectName();
                if (objectName == "Corrupted pic")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[0] + " " + evilObjectDescriptions[0];
                }
                else if (objectName == "Corrupted diary")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[1] + " " + evilObjectDescriptions[1];
                }
                else if (objectName == "Corrupted toy")
                {
                    uiManager.infoObjectDescriptionText.text = objectDescriptions[2] + " "  + evilObjectDescriptions[2];
                }
                dialogueManager.InfluenceMorality(-1f);
                break;
        }
    }
    /// <summary>
    /// When the object type is Evil, checnage the name accordingly
    /// </summary>
    public void UpdateObjectName()
    {
        if (objectType == ObjectType.Evil)
        {
            if (objectName.Contains("Corrupted") == false)
            {
                objectName = "Corrupted " + objectName;
            }
            else
            {
                objectName = objectName;
            }
        }
    }
    /// <summary>
    /// set the material based on the object type
    /// </summary>
    public void SetMaterial()
    {
        Renderer objRenderer = GetComponent<Renderer>();
        if (objectType == ObjectType.Evil)
        {
            objRenderer.material = evilMaterial;
        }
        else
        {
            objRenderer.material = originalMaterial;
        }
    }
    /// <summary>
    /// Set the objects state to Evil
    /// </summary>
    public void SetToEvil()
    {
        objectType = ObjectType.Evil;
        UpdateObjectName();
        SetMaterial();
    }
    /// <summary>
    /// Set the objects state to Info
    /// </summary>
    public void SetToInfo()
    {
        objectType = ObjectType.Info;
        objectName = objectName.Replace("Corrupted ", "");
        SetMaterial();
    }
}

