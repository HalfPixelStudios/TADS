using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static GlobalContainer;

public class CameraController : Possesable {

    [Range(0f,5f)] public float panSpeed;
    [Range(0f, 200f)] public float rotateSpeed;

    Camera cam;

    Transform focus = null;

    //Camera Rotation
    float target_angle = 0;
    int rotateScale = 0;
    float rotatedSoFar = 0;

    void Awake() {
        cam = GetComponentInChildren<Camera>();
        //zoom = cam.orthographicSize;
    }


    private void OnValidate() {
        //cam.orthographicSize = zoom;
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
            //Debug.Log(Global.screenManager.GetScreenClick());
            Vector2 clickPos = Global.screenManager.GetScreenClick();
            Vector3 origin = cam.transform.position;
            origin += cam.transform.up * clickPos.y;
            origin += cam.transform.right * clickPos.x;

            //ray cast and take the first possessable object we hit

            Ray ray = new Ray(origin,cam.transform.forward);
            Debug.DrawRay(origin, cam.transform.forward*100,Color.red,2);

            RaycastHit[] hits = Physics.RaycastAll(ray);
            Possesable p = null;
            if (hits.Length > 0) {
                for (int i = 0; i < hits.Length; i++) {
                    RaycastHit hit = hits[i];
                    p = hit.transform.gameObject.GetComponent<Possesable>();
                    if (p != null) { //grab first object that is possessable
                        Debug.Log("HIT!");
                        break;
                    }
                }
            }
            
            //if possessable is not null, that means we hit something
            if (p != null) { //set it as our focus
                focus = p.transform;
            } else { //if we dont hit anything we unfocus our focus
                focus = null;
            }

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            focus = Global.baby.transform;
        }

        //possess key

        if (Input.GetKeyDown(KeyCode.Space) && focus != null) { //we can only possess something if we are focused on it
            Assert.IsNotNull(focus.gameObject.GetComponent<Possesable>());

            Global.possesor.SetPossessed(focus.gameObject.GetComponent<Possesable>());
        }
    }

    public override void DefaultBehavior() {


        //Unpossess key (when not possessing camera)

        if (Input.GetKeyDown(KeyCode.Space) && Global.possesor.possesing != null) { //when we unpossess anything we default back to posessing the camera
            Global.possesor.SetPossessed(this);
            focus = null;
        }
    }

    public override void AnyBehavior() {
        //Rotate camera input
        if (Input.GetKeyDown(KeyCode.Q) && rotateScale == 0) { //rotate left around focus

            rotateScale = -1;
        } else if (Input.GetKeyDown(KeyCode.E) && rotateScale == 0) {

            rotateScale = +1;
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



        //Camera will now automatically follow what ever object is focused
        if (focus == null) { return; }

        Vector3 pos = transform.position;
        Vector3 target = focus.position;
        float newX = Mathf.Lerp(transform.position.x, target.x, Time.deltaTime * panSpeed);
        float newY = Mathf.Lerp(transform.position.y, target.y, Time.deltaTime * panSpeed);
        float newZ = Mathf.Lerp(transform.position.z, target.z, Time.deltaTime * panSpeed);
        transform.position = new Vector3(newX, newY, newZ);
        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom,0.7f);

    }

    public void SetFocus(Transform focus) {
        this.focus = focus;
    }
    public void RemoveFocus() {
        this.focus = null;
    }

    /*
    public void zoomTo(float zoom)
    {
        this.zoom = zoom;



    }
    */
}
