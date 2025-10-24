using UnityEngine;

public class RaycastPanel : MonoBehaviour
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
        uiPanel.SetActive(false);
    }
}
