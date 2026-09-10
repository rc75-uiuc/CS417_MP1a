using UnityEngine;
using UnityEngine.InputSystem;

public class Quit: MonoBehaviour
{
    public InputActionReference action;
    void start()
    {
        action.action.Enable();
    }
    void Update()
    {
        if (action.action.WasPressedThisFrame())
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
