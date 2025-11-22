using UnityEngine;
using UnityEngine.InputSystem;

public class VRSnapTurn : MonoBehaviour {
    // REFERENCES
    [SerializeField] private Transform xrOriginTransform;
    
    // SETTINGS
    private float _snapAngle = 45f;
    private float _deadzone = 0.7f;
    private float _cooldown = 0.25f;

    private float _cooldownTimer = 0f;

    private void Update() {
        _cooldownTimer -= Time.deltaTime;

        Vector2 turn = UserInputManager.Instance.rightJoystickInput;

        if (_cooldownTimer <= 0f) {
            if (turn.x > _deadzone) {
                SnapTurn(_snapAngle);
            }
            else if (turn.x < -_deadzone) {
                SnapTurn(-_snapAngle);
            }
        }
    }

    private void SnapTurn(float angle) {
        xrOriginTransform.Rotate(0f, angle, 0f);
        _cooldownTimer = _cooldown;
    }
}