using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

[RequireComponent(typeof(Camera))]
public class CameraController : Possesable {

    [Range(0f,5f)]public float panSpeed;
    [Range(0f, 5f)] public float rotateSpeed;

    void Start() {
        
    }



    public override void DefaultBehavior() {
        //Defualt RTS camera controls

        //Pan
        //InputManager im = Global.inputManager;
        Vector2 pan_inp = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        Vector3 pos = transform.position;
        pos += new Vector3(pan_inp.x,0,pan_inp.y) * panSpeed * Time.deltaTime;

        transform.position = pos;

        //Rotate camera
        if (Input.GetKeyDown(KeyCode.Q)) { //rotate left around focus
            StartCoroutine(RotateTo(45));
        } else if (Input.GetKeyDown(KeyCode.E)) {

        }

    }

    public override void PossessedBehavior() {
        //Camera will now automatically follow possesed entity

    }

    /*
    private void Update() {
        
    }
    */
    
    
    IEnumerator RotateTo(float degrees) {
        float target = transform.rotation.y + degrees;
        while (transform.rotation.y < target) {
            transform.RotateAround(Vector3.up, Time.deltaTime * rotateSpeed);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, target, 0); //account for overshooting
        yield return null;

    }
    
    
}
