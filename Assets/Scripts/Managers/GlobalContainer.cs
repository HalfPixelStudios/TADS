using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public ParticleSystem fire;
    public float timer;
    public float timeLimit;
    [SerializeField]private Text t;
    [SerializeField] public GameObject pizza;
    private bool won = false;

    [SerializeField] public GameObject pizzaTruck;


    void Awake() {
        Global = this;
        inputManager = GetComponent<InputManager>();
        possesor = GetComponent<Possesor>();
        screenManager = FindObjectOfType<ScreenManager>();
        captureCam = FindObjectOfType<CameraController>().GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (!won)
        {
            timer += Time.deltaTime;
            t.text= (timeLimit-timer).ToString();
            if (timer > timeLimit)
            {
                dead();
            }
            
        }
        

    }


    public void dead()
    {
        SceneManager.LoadScene("Menu");



    }

    public void win()
    {
        t.text = "You won! Good Job";
        won = true;

    }
}
