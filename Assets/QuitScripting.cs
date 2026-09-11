using UnityEngine;
using UnityEngine.XR;

public class QuitGame : MonoBehaviour
{
    private InputDevice leftController;
    private bool previousButtonState = false;

    void Start()
    {
        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    void Update()
    {
        bool buttonPressed;

        if (leftController.TryGetFeatureValue(
            CommonUsages.primaryButton,
            out buttonPressed))
        {
            if (buttonPressed && !previousButtonState)
            {
                Quit();
            }

            previousButtonState = buttonPressed;
        }
    }

    void Quit()
    {
        Debug.Log("Quitting game");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}