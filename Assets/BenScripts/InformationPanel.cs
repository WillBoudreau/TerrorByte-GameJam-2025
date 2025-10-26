
using UnityEngine;

public class InformationPanel : MonoBehaviour
{
    public GameObject uiPanel;// Reference to the UI panel to display
    public float range;
    [SerializeField] private UIManager uiManager;
    private void Start()
    {
        uiPanel.SetActive(false);
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Opens panel if player clicks on object with "Interactable"
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                if (hit.collider.CompareTag("Interactable"))
                {
                    hit.collider.GetComponent<InteractableOBJ>().Interact();
                }
                else if(hit.collider.CompareTag("EvilSide"))
                {
                    uiManager.TogglePanel("EvilDialogue");
                }
            }

        }
    }

    public void ClosePanel()
    {
        //close panel if player clicks Close button.
        uiPanel.SetActive(false);
    }
}
