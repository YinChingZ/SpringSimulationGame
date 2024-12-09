using UnityEngine;

public class SpringSimulation : MonoBehaviour
{
    public float elasticity = 1.0f;
    public float weight = 1.0f;
    public float decay = 0.1f;
    public Transform objectUnderSpring;
    public Transform springTransform;  // Transform representing the spring

    private Vector3 initialPosition;
    private Vector3 initialScale;  // Initial scale of the spring
    private Vector3 velocity;

    void Start()
    {
        if (objectUnderSpring == null)
        {
            Debug.LogError("Object under spring is not assigned.");
            return;
        }

        if (springTransform == null)
        {
            Debug.LogError("Spring transform is not assigned.");
            return;
        }

        initialPosition = objectUnderSpring.position;
        initialScale = springTransform.localScale;
        RestartOscillation();
    }

    void Update()
    {
        if (objectUnderSpring == null || springTransform == null)
        {
            return;
        }

        float displacement = objectUnderSpring.position.y - initialPosition.y;
        float springForce = -elasticity * displacement;
        float dampingForce = -decay * velocity.y;
        float totalForce = springForce + dampingForce;

        velocity.y += totalForce / weight * Time.deltaTime;
        objectUnderSpring.position += velocity * Time.deltaTime;

        // Update the spring's scale to visually represent stretching/compressing
        float stretchFactor = 1 - displacement / initialScale.y; // Invert the stretch factor
        springTransform.localScale = new Vector3(initialScale.x, initialScale.y * stretchFactor, initialScale.z);

        Debug.Log($"Displacement: {displacement}, Spring Force: {springForce}, Damping Force: {dampingForce}, Total Force: {totalForce}, Velocity: {velocity}, Position: {objectUnderSpring.position}");
    }

    public void RestartOscillation()
    {
        if (objectUnderSpring == null || springTransform == null)
        {
            Debug.LogError("Object under spring or spring transform is not assigned.");
            return;
        }

        objectUnderSpring.position = initialPosition;
        springTransform.localScale = initialScale;
        velocity = new Vector3(0, 1, 0);  // Initial velocity to start the oscillation
    }
}