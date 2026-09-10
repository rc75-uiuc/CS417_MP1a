using UnityEngine;
using UnityEngine.InputSystem;

public class Quit: MonoBehaviour
{
    public InputActionReference action;
    void start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };
    }
}
