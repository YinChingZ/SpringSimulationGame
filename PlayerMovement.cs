using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 700f;

    void Update()
    {
        // Get input from the player
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Move the player forward/backward
        transform.Translate(0, 0, translation);

        // Rotate the player left/right
        transform.Rotate(0, rotation, 0);
    }
}