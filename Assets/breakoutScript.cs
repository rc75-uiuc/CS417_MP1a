using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
    public InputActionReference action;
    public Transform breakoutPlane;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private bool isOutside = false;

    void Start()
    {
        // Remember the player's initial position and rotation
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    void Update()
    {
        if (action.action.WasPressedThisFrame())
        {
            if (isOutside)
            {
                // Return to the original spawn position
                transform.position = spawnPosition;
                transform.rotation = spawnRotation;
                isOutside = false;
            }
            else
            {
                // Move to the BreakoutPlane
                transform.position = breakoutPlane.position;
                transform.rotation = breakoutPlane.rotation;
                isOutside = true;
            }
        }
    }
}