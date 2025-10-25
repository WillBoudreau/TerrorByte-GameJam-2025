using UnityEngine;

public class RaycastPanel : MonoBehaviour
{
    public GameObject uiPanel;// Reference to the UI panel to display
    private UIManager uiManager;
    private void Start()
    {
        uiPanel.SetActive(false);
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    uiPanel.SetActive(true);
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
        uiPanel.SetActive(false);
    }
}
