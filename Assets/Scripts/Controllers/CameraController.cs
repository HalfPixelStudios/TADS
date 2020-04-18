using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

[RequireComponent(typeof(Camera))]
public class CameraController : Possesable {

    [Range(0f,5f)]public float panSpeed;

    void Start() {
        
    }



    public override void DefaultBehavior() {
        //Defualt RTS camera controls

        Vector2 inp = Global.inputManager.cameraPan;
        //Debug.Log(inp);

        Vector3 pos = transform.position;
        pos += new Vector3(inp.x,0,inp.y) * panSpeed * Time.deltaTime;

        transform.position = pos;

    }

    public override void PossessedBehavior() {
        //Camera will now automatically follow possesed entity

    }
}
