using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possesor : MonoBehaviour {

    public Possesable possesing;
    GameObject possessCursor;

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

        //Spawn possess target
        if (target.GetComponent<CameraController>() == null) { //if not camera
            possessCursor = Instantiate(Resources.Load("possessCursor") as GameObject);
            possessCursor.GetComponent<CursorBob>().following = possesing.transform;
        } else if (possessCursor != null) { //otherwise if we are possessing the camera, destroy the cursor
            Destroy(possessCursor);
            possessCursor = null;
        }
        
    }




    /*
    private void OnDrawGizmos() {
        if (possesable == null) { return; }
        Gizmos.DrawIcon(possesable.transform.position,);
    }
    */
}
