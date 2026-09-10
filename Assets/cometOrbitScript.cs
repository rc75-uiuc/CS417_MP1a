using UnityEngine;

public class cometOrbitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 velocity;
    public float gravity = 0.2f;
    public Transform gravityCenter;

    void Update()
    {
        // Position relative to the gravity center
        Vector3 position = transform.position - gravityCenter.position;
        // Distance from gravity center
        float distance = position.magnitude;

        if (distance > 0.01f) //to avoid any nasty divide by 0 incidents hopefully
        {
            Vector3 acceleration =
                -gravity * position / Mathf.Pow(distance, 3);
            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
