using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;// Sensitivity multiplier for mouse movement
    [SerializeField] private float lookEdgeThreshold = 50f;// Distance from screen edge to trigger look indicators
    private float xRotation = 0f;// Current rotation around the Y-axis
    private float zRotation = 0f;// Current rotation around the Z-axis
    [Header("Mouse References")]
    [SerializeField] private GameObject playerCamera;// Reference to the player's camera
    [SerializeField] private GameObject lookUpIndicator;// UI element to indicate looking up
    [SerializeField] private GameObject lookDownIndicator;// UI element to indicate looking down
    [SerializeField] private GameObject lookRightIndicator;// UI element to indicate looking right
    [SerializeField] private GameObject lookLeftIndicator;// UI element to indicate looking left
    [Header("Rotation Settings")]
    [SerializeField] private float maxLookAngle = 80f;// Maximum angle the player can look up or down
    [SerializeField] private float minLookAngle = -80f;// Minimum angle the player can look up or down
    [SerializeField] private Transform transformY;// Reference to the player's body transform for Y-axis rotation
    void Update()
    {
        TrackCursor();
    }
    /// <summary>
    /// Track the mouse location on screen, displaying indicators when looking near the edges.
    /// </summary>
    private void TrackCursor()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Check for look up
        if (mousePosition.y >= screenHeight - lookEdgeThreshold)
            lookUpIndicator.SetActive(true);
        else
            lookUpIndicator.SetActive(false);

        // Check for look down
        if (mousePosition.y <= lookEdgeThreshold)
            lookDownIndicator.SetActive(true);
        else
            lookDownIndicator.SetActive(false);

        // Check for look right
        if (mousePosition.x >= screenWidth - lookEdgeThreshold)
            lookRightIndicator.SetActive(true);
        else
            lookRightIndicator.SetActive(false);

        // Check for look left
        if (mousePosition.x <= lookEdgeThreshold)
            lookLeftIndicator.SetActive(true);
        else
            lookLeftIndicator.SetActive(false);
    }
    /// <summary>
    /// Handles the player's look rotation based on mouse input.
    /// direction - "up", "down", "left", or "right"
    /// </summary>
    public void HandleLook(string direction)
    {
        switch (direction)
        {
            case "up":
                StartCoroutine(RotateCamera("up"));
                break;
            case "down":
                StartCoroutine(RotateCamera("down"));
                break;
            case "left":
                StartCoroutine(RotateCamera("left"));
                break;
            case "right":
                StartCoroutine(RotateCamera("right"));
                break;
        }
    }
    /// <summary>
    /// Changes the rotation of the camera to face the new direction.
    /// </summary>
    private IEnumerator RotateCamera(string direction)
    {
        switch (direction)
        {
            case "up":
                if (xRotation < maxLookAngle)
                {
                    xRotation += maxLookAngle;
                    playerCamera.transform.localRotation = Quaternion.Euler(-xRotation, 0f, 0f);
                }
                else
                {
                    xRotation = maxLookAngle;
                }
                yield return null;
                break;
            case "down":
                if (xRotation > minLookAngle)
                {
                    xRotation += minLookAngle;
                    playerCamera.transform.localRotation = Quaternion.Euler(-xRotation, 0f, 0f);
                }
                else
                {
                    xRotation = minLookAngle;
                }
                yield return null;
                break;
            case "left":
                if (zRotation < maxLookAngle)
                {
                    zRotation += maxLookAngle;
                    playerCamera.transform.localRotation = Quaternion.Euler(0f, zRotation, 0f);
                }
                else
                {
                    zRotation = maxLookAngle;
                }
                yield return null;
                break;
            case "right":
                if (zRotation > minLookAngle)
                {
                    zRotation += minLookAngle;
                    playerCamera.transform.localRotation = Quaternion.Euler(0f, zRotation, 0f);
                }
                else
                {
                    zRotation = minLookAngle;
                }
                yield return null;
                break;
        }
    }
}
