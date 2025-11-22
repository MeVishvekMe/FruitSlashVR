using System;
using UnityEngine;

public class UserInputManager : MonoBehaviour {
    public static UserInputManager Instance;

    private VrInputActionAsset _vrInputActionAsset;

    public Vector2 leftJoystickInput;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            _vrInputActionAsset = new VrInputActionAsset();
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        _vrInputActionAsset.Enable();
        
        _vrInputActionAsset.XRLeftControllerInteraction.Enable();
    }

    private void OnDisable() {
        _vrInputActionAsset.Disable();
        _vrInputActionAsset.XRLeftControllerInteraction.Disable();
    }

    private void Update() {
        leftJoystickInput = _vrInputActionAsset.XRLeftControllerInteraction.Joystick.ReadValue<Vector2>();
    }
}