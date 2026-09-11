using UnityEngine;
using UnityEngine.XR;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    private InputDevice rightController;
    private bool previousTriggerState = false;

    void Start()
    {
        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        bool triggerPressed;

        if (rightController.TryGetFeatureValue(
            CommonUsages.triggerButton,
            out triggerPressed))
        {
            if (triggerPressed && !previousTriggerState)
            {
                SpawnObject();
            }

            previousTriggerState = triggerPressed;
        }
    }

    void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}