using UnityEngine;

public class Plane_Controller : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;

    [Header("Rotation")]
    public float rollAmount = 30f;
    public float pitchAmount = 20f; 
    public float turnSpeed = 50f; 
    public float rotationSmooth = 8f;

    [Header("Rotation Offset")]
    public Vector3 rotationOffset;

    private Vector2 input;
    private float currentYaw;

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        currentYaw += input.x * turnSpeed * Time.deltaTime;

        float rollZ = -input.x * rollAmount;
        float pitchX = -input.y * pitchAmount;

        Quaternion targetVisualRotation = Quaternion.Euler(
            pitchX + rotationOffset.x,
            rotationOffset.y,
            rollZ + rotationOffset.z
        );

        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            rotation * targetVisualRotation,
            Time.deltaTime * rotationSmooth
        );
    }
}
