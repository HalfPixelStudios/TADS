using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;
    [HideInInspector] public InputManager inputManager;
    public Transform turnPoints;

    void Awake() {
        Global = this;
        inputManager = GetComponent<InputManager>();
    }

    void Update() {
        
    }
}
