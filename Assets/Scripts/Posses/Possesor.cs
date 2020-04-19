using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possesor : MonoBehaviour {

    public Possesable possesing;

    private void Awake() {
        //start off by possessing the camera
        SetPossessed((Possesable)FindObjectOfType<CameraController>());
    }

    public void SetPossessed(Possesable target) {
        if (possesing != null) {
            possesing.isPossessed = false;
        }
        target.isPossessed = true;
        possesing = target;
    }

    /*
    private void OnDrawGizmos() {
        if (possesable == null) { return; }
        Gizmos.DrawIcon(possesable.transform.position,);
    }
    */
}
