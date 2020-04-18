using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [Range(0f, 1f)] public float inputThreshold;

    PlayerInputActions inputActions;

    //Camera controls
    public Vector2 cameraPan;
    public float cameraRotateLeft;
    public float cameraRotateRight;

    void Awake() {
        inputActions = new PlayerInputActions();

        //Camera controls
        inputActions.CameraActions.Pan.performed += ctx => cameraPan = ctx.ReadValue<Vector2>();
        inputActions.CameraActions.RotateLeft.performed += ctx => cameraRotateLeft = ctx.ReadValue<float>();
        inputActions.CameraActions.RotateRight.performed += ctx => cameraRotateRight = ctx.ReadValue<float>();
    }


    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }
}
