using UnityEngine;
using UnityEngine.XR;

public class PlayerTeleport : MonoBehaviour
{
    public Transform breakoutPlane;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private InputDevice controller;
    private bool previousButtonState = false;
    private bool isOutside = false;

    void Start()
    {
        // Remember initial player position
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;

        // Get the right-hand controller
        controller = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        bool buttonState;

        if (controller.TryGetFeatureValue(
            CommonUsages.primaryButton,
            out buttonState))
        {
            // Detect a new button press rather than holding the button
            if (buttonState && !previousButtonState)
            {
                TogglePosition();
            }

            previousButtonState = buttonState;
        }
    }

    void TogglePosition()
    {
        if (isOutside)
        {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
            isOutside = false;
        }
        else
        {
            transform.position = breakoutPlane.position;
            transform.rotation = breakoutPlane.rotation;
            isOutside = true;
        }
    }
}