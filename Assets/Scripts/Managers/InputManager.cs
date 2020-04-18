using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    PlayerInputActions inputActions;

    //Camera controls
    public Vector2 cameraPan;

    void Awake() {
        inputActions = new PlayerInputActions();

        //Camera controls
        inputActions.CameraActions.Pan.performed += ctx => cameraPan = ctx.ReadValue<Vector2>();
    }


    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }
}
