using UnityEngine;
using UnityEngine.XR;

public class LightScripting : MonoBehaviour
{
    public Light light;

    private InputDevice rightController;
    private bool previousButtonState = false;
    private bool isRed = false;

    void Start()
    {
        light = GetComponent<Light>();

        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        light.color = Color.white;
    }

    void Update()
    {
        bool buttonPressed;

        if (rightController.TryGetFeatureValue(
            CommonUsages.secondaryButton,
            out buttonPressed))
        {
            if (buttonPressed && !previousButtonState)
            {
                ToggleLight();
            }

            previousButtonState = buttonPressed;
        }
    }

    void ToggleLight()
    {
        isRed = !isRed;

        if (isRed)
        {
            light.color = new Color(0.8f, 0.08f, 0.08f);
        }
        else
        {
            light.color = Color.white;
        }
    }
}