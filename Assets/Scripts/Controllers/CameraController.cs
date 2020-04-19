using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static GlobalContainer;

public class CameraController : Possesable {

    [Range(0f,5f)] public float panSpeed;
    [Range(0f, 200f)] public float rotateSpeed;

    Camera cam;

    Transform focus;

    //Camera Rotation
    float target_angle = 0;
    int rotateScale = 0;
    float rotatedSoFar = 0;

    void Awake() {
        cam = GetComponentInChildren<Camera>();
    }

    public override void PossessedBehavior() {
        //Defualt RTS camera controls

        //Pan
        //InputManager im = Global.inputManager;
        Vector2 pan_inp = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        if (pan_inp != Vector2.zero) {
            Vector3 pos = transform.position;

            //move in direction cam is facing
            Vector3 forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            pos += forward * pan_inp.y * panSpeed * Time.deltaTime;
            pos += cam.transform.right * pan_inp.x * panSpeed * Time.deltaTime;

            transform.position = pos;
        }


        //Click on screen, if there is a possessable object, focus on it
        if (Input.GetMouseButtonDown(0)) {

            //first find position on output screen and map it to capture cam
            Debug.Log(Global.screenManager.GetScreenClick());


            //ray cast and take the first possessable object we hit

            
            //set it as our focus


            //if we dont hit anything we unfocus our focus

        }

        //possess key
        if (Input.GetKeyDown(KeyCode.E) && Global.possesor.possesable == null && focus != null) { //we can only possess something if we are focused on it
            Assert.IsNotNull(focus.gameObject.GetComponent<Possesable>());

            Global.possesor.SetPossessed(focus.gameObject.GetComponent<Possesable>());
        }
    }

    public override void DefaultBehavior() {

        if (focus == null) { return; }

        //Camera will now automatically follow what ever object is focused

        Vector3 pos = transform.position;
        Vector3 target = focus.position;
        float newX = Mathf.Lerp(transform.position.x, target.x, Time.deltaTime*panSpeed);
        float newY = Mathf.Lerp(transform.position.y, target.y, Time.deltaTime * panSpeed);
        float newZ = Mathf.Lerp(transform.position.z, target.z, Time.deltaTime * panSpeed);
        transform.position = new Vector3(newX, newY, newZ);
    }

    public override void AnyBehavior() {
        //Rotate camera input
        if (Input.GetKeyDown(KeyCode.Q) && rotateScale == 0) { //rotate left around focus

            rotateScale = 1;
        } else if (Input.GetKeyDown(KeyCode.E) && rotateScale == 0) {

            rotateScale = -1;
        }

        if (rotateScale != 0) {
            float step = Time.deltaTime * rotateSpeed * rotateScale;
            cam.transform.RotateAround(transform.position, Vector3.up, step);
            rotatedSoFar += Mathf.Abs(step);
        }

        if (rotatedSoFar > 90) {
            cam.transform.RotateAround(transform.position, Vector3.up, (rotatedSoFar-90)*rotateScale*(-1));
            rotateScale = 0;
            rotatedSoFar = 0;
        }

        

        //Camera always looks at focus
        cam.transform.LookAt(cam.transform.parent);


        //Unpossess key
        if (Input.GetKeyDown(KeyCode.E) && Global.possesor.possesable != null) { //when we unpossess anything we default back to posessing the camera
            Global.possesor.SetPossessed(this);
        }
    }

    public void SetFocus(Transform focus) {
        this.focus = focus;
    }
    public void RemoveFocus() {
        this.focus = null;
    }


}
