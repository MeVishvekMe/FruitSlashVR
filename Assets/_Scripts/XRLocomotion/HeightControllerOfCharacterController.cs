using System;
using UnityEngine;

public class HeightControllerOfCharacterController : MonoBehaviour {
    [SerializeField] private Transform mainCameraTransform;
    [SerializeField] private CharacterController _characterController;

    private float extraHeight = 0.2f;

    private void Update() {
        UpdateCharacterControllerHeight();
    }

    private void UpdateCharacterControllerHeight() {
        float cameraHeight = mainCameraTransform.localPosition.y + extraHeight;
        _characterController.height = cameraHeight;
        _characterController.center = new Vector3(0f, cameraHeight / 2f + _characterController.radius, 0f);
    }
}