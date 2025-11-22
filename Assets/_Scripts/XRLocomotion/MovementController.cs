using System;
using UnityEngine;

public class MovementController : MonoBehaviour {
    // REFERENCES
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;
    
    // SETTINGS
    private float _moveSpeed = 2f;
    private float _gravity = -9.81f;
    private float _verticalVelocity;

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 joystickInput = UserInputManager.Instance.leftJoystickInput;

        Vector3 forward = _cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = _cameraTransform.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDirection = (forward * joystickInput.y) + (right * joystickInput.x);
        Vector3 horizontalMove = moveDirection * _moveSpeed;

        if (_characterController.isGrounded) {
            _verticalVelocity = -1f;
        }
        else {
            _verticalVelocity += _gravity * Time.deltaTime;
        }

        Vector3 verticalMove = Vector3.up * _verticalVelocity;

        _characterController.Move((horizontalMove + verticalMove) * Time.deltaTime);
    }
}
