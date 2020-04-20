using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(InputManager),typeof(Possesor))]
public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public Possesor possesor;
    public ScreenManager screenManager;
    public Camera captureCam;
    public GameObject endUI;
    public GameObject baby;
    public ParticleSystem fire;
    public float timer;
    public float timeLimit;
    private Text t;
    [SerializeField] public GameObject pizza;



    void Awake() {
        Global = this;
        inputManager = GetComponent<InputManager>();
        possesor = GetComponent<Possesor>();
        screenManager = FindObjectOfType<ScreenManager>();
        captureCam = FindObjectOfType<CameraController>().GetComponentInChildren<Camera>();
    }

    void Update()
    {
        timer += Time.deltaTime;
         t.text= timeLimit-timer;
        if (timer > timeLimit)
        {
            dead();
        }

    }


    public void dead()
    {
        
        
    }

    public void win()
    {
        //Camera.main.GetComponent<CameraController>().zoomTo(100);
    }
}
