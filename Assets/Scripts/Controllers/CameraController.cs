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
    bool isRotating;
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
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating) { //rotate left around focus
            target = cam.transform.rotation.y - Mathf.PI/2;
            isRotating = true;
        } else if (Input.GetKeyDown(KeyCode.E) && !isRotating) {
            target = cam.transform.rotation.y - Mathf.PI / 2;
            isRotating = true;
        }

        if (isRotating) {
            float step = Mathf.Lerp(cam.transform.rotation.y,target,Time.deltaTime*rotateSpeed);

            /*
            Debug.Log($"{cam.transform.rotation.y}, {target}, {AngleDifference(cam.transform.rotation.y, target)}, {step}");
            if (AngleDifference(cam.transform.rotation.y,target) <= Mathf.Abs(step)) {
                Debug.Log("end");
                //cam.transform.rotation = Quaternion.Euler(transform.rotation.x,target,transform.rotation.z);
                isRotating = false;
            }
            */
            cam.transform.RotateAround(transform.position, Vector3.up, step);
            rotatedSoFar += Mathf.Abs(step);
        }

        if (rotatedSoFar > 90) {
            isRotating = false;
            rotatedSoFar = 0;
            cam.transform.rotation = Quaternion.Euler(transform.rotation.x, target, transform.rotation.z);
        }

        

        //Camera always looks at focus
        cam.transform.LookAt(cam.transform.parent);
        
    }

    public static float AngleDifference(float a, float b) {
        return AngleNormalizer(Mathf.Abs(AngleNormalizer(a) - AngleNormalizer(b)));
    }
    public static float AngleNormalizer(float a) {
        
        if (a > Mathf.PI*2) {
            float result = a;
            while (result > Mathf.PI*2) {
                result -= Mathf.PI * 2;
            }
            return result;
        } else if (a < 0) {
            float result = a;
            while (result < 0) {
                result += Mathf.PI * 2;
            }
            return result;
        }
        return a;
    }

    /*
    public static float AngleDist(float a, float b) {
        float phi = Mathf.Abs()
    }
    */

}
