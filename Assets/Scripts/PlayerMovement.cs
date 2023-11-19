using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float mouseSensitivity = 1.7f;
    private float cameraVerticalRotation = 0f;
    private float speedPerUnit = 2.0f;
    [SerializeField] private Transform cameraTransform;
    private CharacterController characterController;
    private bool freezeMovement = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();

        EventManager.AddListener(EventEnum.OnCameraGetIn, DisableMovement);
        EventManager.AddListener(EventEnum.OnCameraGetOut, EnableMovement);
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= mouseInputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -75f, 75);
        cameraTransform.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);

        transform.Rotate(Vector3.up, mouseInputX);

        // Change Position
        if (!freezeMovement)
        {
            float moveInputX = Input.GetAxis("Horizontal");
            float moveInputY = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveInputX + transform.forward * moveInputY;
            Vector3.Normalize(move);

            characterController.SimpleMove(move * speedPerUnit);
        }
    }

    public void DisableMovement()
    {
        freezeMovement = true;
    }
    public void EnableMovement()
    {
        freezeMovement = false;
    }
}
