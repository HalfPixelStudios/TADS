using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]private TrafficLightPoint _trafficLightPoint;

    private Material redLight;
    private Material greenLight;
    void Start()
    {
        var materials = GetComponent<MeshRenderer>().materials;
        redLight = materials[1];
        greenLight = materials[2];



    }

    
    void Update()
    {
        if (_trafficLightPoint.state == TrafficLightPoint.TrafficLight.RED)
        {
            redLight.EnableKeyword("_EMISSION");
            greenLight.DisableKeyword("_EMISSION");
            
        }
        else
        {
            greenLight.EnableKeyword("_EMISSION");
            redLight.DisableKeyword("_EMISSION");
        }
        
        
    }
}
