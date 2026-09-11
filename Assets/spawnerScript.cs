using UnityEngine;
using UnityEngine.XR;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float projectileSpeed = 5f;

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
        GameObject newObject = Instantiate(
            objectToSpawn,
            spawnPoint.position,
            spawnPoint.rotation
        );

        Projectile projectile = newObject.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.velocity = spawnPoint.forward * projectileSpeed;
        }
    }
}