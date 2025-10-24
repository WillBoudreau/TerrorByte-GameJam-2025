using UnityEngine;

public class InformationPanel : MonoBehaviour
{

    public GameObject uiPanel;

    void Start()
    {
        uiPanel.SetActive(false);
    }

    void Update()
    {
        //press Object with tag and panel appears...

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
            }

        }
    }

    public void ClosePanel()
    {
        //used for close button
        uiPanel.SetActive(false);
    }
}
