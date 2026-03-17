using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRoller : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 5f;
    public float jumpForce = 1f;

    [Header("Camera Settings")]
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;
    public float distanceFromPlayer = 5f;
    public float heightFromPlayer = 2f;

    private Rigidbody rb;
    private float mouseX;
    private float mouseY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        if(cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;

        mouseY = Mathf.Clamp(mouseY, -80f, 80f);

        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0)){
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        rb.AddForce(movement * moveForce);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;

        }
    }

    void LateUpdate()
    {

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        Vector3 offset = new Vector3(0f, heightFromPlayer, -distanceFromPlayer);

        cameraTransform.position = transform.position + rotation * offset;
        cameraTransform.LookAt(transform.position + Vector3.up * heightFromPlayer * 0.5f);
    }
}