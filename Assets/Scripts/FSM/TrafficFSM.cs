﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficFSM : MonoBehaviour
{
    public List<TrafficLightPoint> NSLights;

    public List<TrafficLightPoint> EWLights;

    public List<TrafficLightPoint> PedNSLights;

    public List<TrafficLightPoint> PedEWLights;
    // Start is called before the first frame update
    private bool NSGo;
    private float timer=0;
    void Start()
    {
        NSGo = true;
        


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            NSGo = !NSGo;
            updateLights();
        }
    }

    private void updateLights()
    {
        
        TrafficLightPoint.TrafficLight NS;
        TrafficLightPoint.TrafficLight EW;
        
        if (NSGo)
        {
            NS = TrafficLightPoint.TrafficLight.GREEN;
            EW = TrafficLightPoint.TrafficLight.RED;

        }
        else
        {
            NS = TrafficLightPoint.TrafficLight.RED;
            EW = TrafficLightPoint.TrafficLight.GREEN;
            
        }
        
        foreach (var l in NSLights)
        {
            l.setState(NS);
        }
        foreach (var l in EWLights)
        {
            l.setState(EW);

        }
        foreach (var l in PedNSLights)
        {
            l.setState(NS);

        }
        foreach (var l in PedEWLights)
        {
            l.setState(EW);

        }
        
    }
}
