using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject quitButton;
    public GameObject resumeButton;

    public CharacterController controller;
    private Vector3 velocity;

    public float gravity = -20f;
    public float groundDistance = 0.4f;
    private bool isGrounded;

    public float jumpHeight = 2f;

    // Sprinting variables
    public float sprintMultiplier = 6f;
    private bool isSprinting = false;

    private void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Capture mouse input for rotation
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Limit the pitch to avoid camera flipping
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Rotate the entire player object (including the camera) based on mouse input
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        // Rotate only the camera based on mouse input
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Check if the Left Shift key is pressed for sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Adjust speed based on whether sprinting is happening
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;

        // Apply sprinting effect
        controller.Move(move * currentSpeed * Time.deltaTime + velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitButton.SetActive(true);
            resumeButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quitButton.SetActive(false);
        resumeButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
