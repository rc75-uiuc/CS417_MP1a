using UnityEngine;
using UnityEngine.InputSystem;


public class LightScripting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Light light;
    public InputActionReference action;
    private bool isRed = false;
    void Start()
    {
        light = GetComponent<Light>();
        light.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPressedThisFrame())
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
}
