using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GlobalContainer;

[RequireComponent(typeof(Renderer))]
public class ScreenManager : MonoBehaviour {

    public int pixelsPerUnit;


    //resizes capture cam / output cam so it fits screen size

    void Start() {

        //Set size of main cam
        float screenHeight = 2 * Camera.main.orthographicSize;
        float screenWidth = screenHeight * Camera.main.aspect;

        //Set size of capture cam
        //Global.captureCam.orthographicSize = Camera.main.orthographicSize;


        //Set size of render texture
        RenderTexture tex = new RenderTexture((int)screenWidth * pixelsPerUnit, (int)screenHeight * pixelsPerUnit, 24);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;
        Global.captureCam.targetTexture = tex;

        //Set size of output plane
        transform.localScale = new Vector3(screenWidth / 10, 1, screenHeight / 10);
        GetComponent<Renderer>().sharedMaterial.mainTexture = tex;

        
    }

    void Update() {
        
    }


    public Vector2 GetScreenClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 hitPosition = new Vector3(-1000,-1000,-1000);
        if (Physics.Raycast(ray, out hit)) {
            hitPosition = hit.point;
        }

        //make click position start at the bottom left corner
        float screenX = hitPosition.x - transform.position.x;
        float screenY = hitPosition.y - transform.position.y;

        Vector2 clickPosition = new Vector2(screenX,screenY);

        return clickPosition;

    }



}
