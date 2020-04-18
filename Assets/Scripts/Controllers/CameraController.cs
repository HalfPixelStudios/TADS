using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class CameraController : Possesable {

    [Range(0f,5f)] public float panSpeed;
    [Range(0f, 200f)] public float rotateSpeed;

    Camera cam;

    //Camera Rotation
    float target = 0;
    int rotateScale = 0;
    float rotatedSoFar = 0;

    void Awake() {
        cam = GetComponentInChildren<Camera>();
    }



    public override void DefaultBehavior() {
        //Defualt RTS camera controls

        //Pan
        //InputManager im = Global.inputManager;
        Vector2 pan_inp = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        if (pan_inp != Vector2.zero) {
            Vector3 pos = transform.position;

            pos += new Vector3(pan_inp.x + cam.transform.forward.x, 0, pan_inp.y + cam.transform.forward.y) * panSpeed * Time.deltaTime;

            //transform.Translate(new Vector3(pan_inp.x, 0, pan_inp.y) * panSpeed * Time.deltaTime);
            transform.position = pos;
        }




    }

    public override void PossessedBehavior() {
        //Camera will now automatically follow possesed entity

    }

    public override void AnyBehavior() {
        //Rotate camera input
        if (Input.GetKeyDown(KeyCode.Q) && rotateScale == 0) { //rotate left around focus

            rotateScale = -1;
        } else if (Input.GetKeyDown(KeyCode.E) && rotateScale == 0) {

            rotateScale = 1;
        }

        if (rotateScale != 0) {
            //cam.transform.RotateAround
        }

        if (rotatedSoFar > 90) {

        }

        

        //Camera always looks at focus
        cam.transform.LookAt(cam.transform.parent);
        
    }


}
