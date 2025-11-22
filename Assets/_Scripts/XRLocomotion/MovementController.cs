using System;
using UnityEngine;

public class MovementController : MonoBehaviour {
    // REFERENCES
    [SerializeField] private CharacterController _characterController;
    [SerializeField] public Transform cameraTransform;
    
    // SETTINGS
    private float moveSpeed = 2f;
    private float gravity = -9.81f;
    private float verticalVelocity;

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 joystickInput = UserInputManager.Instance.leftJoystickInput;

        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDirection = (forward * joystickInput.y) + (right * joystickInput.x);
        Vector3 horizontalMove = moveDirection * moveSpeed;

        if (_characterController.isGrounded) {
            verticalVelocity = -1f;
        }
        else {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 verticalMove = Vector3.up * verticalVelocity;

        _characterController.Move((horizontalMove + verticalMove) * Time.deltaTime);
    }
}
