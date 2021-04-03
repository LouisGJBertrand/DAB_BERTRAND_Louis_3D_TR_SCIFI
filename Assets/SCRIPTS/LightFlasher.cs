using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlasher : MonoBehaviour
{

    public Light Light;

    public float FlashIntensity = 2;
    public float FlashThreshold = 0.8f;
    public float FlashSpeed = 1;

    public float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        t = (t + Time.deltaTime * FlashSpeed) % Mathf.PI;

        Light.intensity = (Mathf.Sin(t) < FlashThreshold ? 0 : FlashIntensity);

    }
}
