using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanFlickeringLight : MonoBehaviour
{
    public Light Light;
    public float FlickeringChance = 0.01f;
    public bool IsFlickeringInverted = true;

    public float MaxLightIntensity = 1;
    public float MinLightIntensity = 0;

    public float flicker = 0;
    public float flickerSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Light.intensity = (float)Math.Tan(flicker) * MaxLightIntensity + MinLightIntensity;
        flicker = (float)((flicker + Time.deltaTime * flickerSpeed) % Math.PI);

    }
}
