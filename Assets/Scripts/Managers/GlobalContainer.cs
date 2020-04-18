using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager),typeof(Possesor))]
public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public Possesor possesor;
    

    void Awake() {
        Global = this;
        inputManager = GetComponent<InputManager>();
        possesor = GetComponent<Possesor>();
    }

    void Update() {
        
    }
}
