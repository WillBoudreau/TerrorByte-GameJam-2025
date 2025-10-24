using UnityEngine;

public class InformationPanel : MonoBehaviour
{

    public GameObject uiPanel;

    private void Start()
    {
        uiPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Opens panel if player clicks on object with "Interactable"
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    uiPanel.SetActive(true);
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
