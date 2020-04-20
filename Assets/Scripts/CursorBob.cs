using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBob : MonoBehaviour {

    public Transform following;
    public Vector3 parentOffset;
    [Range(0f, 100f)] public float rotateSpeed;
    [Range(0f, 100f)] public float bobSpeed;
    public float bobAmplitude;

    void Update() {
        //Rotate
        transform.Rotate(new Vector3(0,0,1), rotateSpeed * Time.deltaTime);

        //Bob up and down
        Vector3 pos = following.position;
        float y = Mathf.Sin(Time.time*bobSpeed)*bobAmplitude;
        transform.position = new Vector3(pos.x+parentOffset.x, pos.y+y+parentOffset.y, pos.z+parentOffset.z);
    }
}
