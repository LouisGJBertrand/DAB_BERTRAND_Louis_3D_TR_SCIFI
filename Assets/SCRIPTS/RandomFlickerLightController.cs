using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlickerLightController : MonoBehaviour
{

    public List<Light> Lights;
    public float FlickeringChance = 0.01f;
    public bool IsFlickeringInverted = true;

    public float MaxLightIntensity = 1;
    public float MinLightIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(Light light in Lights)
        {
            if(Random.value <= FlickeringChance)
            {
                light.intensity = !IsFlickeringInverted ? MaxLightIntensity : MinLightIntensity;
            } else
            {
                light.intensity = IsFlickeringInverted ? MaxLightIntensity : MinLightIntensity;
            }
        }

    }
}
