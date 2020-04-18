using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possesor : MonoBehaviour {

    public Possesable possesable;

    private void Awake() {
        //start off by possessing the camera
        SetPossessed((Possesable)FindObjectOfType(typeof(CameraController)));
    }

    public void SetPossessed(Possesable target) {
        if (possesable != null) {
            possesable.isPossessed = false;
        }
        target.isPossessed = true;
    }

    /*
    private void OnDrawGizmos() {
        if (possesable == null) { return; }
        Gizmos.DrawIcon(possesable.transform.position,);
    }
    */
}
