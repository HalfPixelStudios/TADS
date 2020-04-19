using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager),typeof(Possesor))]
public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public Possesor possesor;
    public ScreenManager screenManager;
    public Camera captureCam;
    

    void Awake() {
        Global = this;
        inputManager = GetComponent<InputManager>();
        possesor = GetComponent<Possesor>();
        screenManager = FindObjectOfType<ScreenManager>();
        captureCam = FindObjectOfType<CameraController>().GetComponentInChildren<Camera>();
    }

    void Update() {
        
    }
}
