using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{

    public Light SpotLight;
    public bool IsSpotlightOn = false;
    public AudioSource AudioSource;
    public AudioClip AudioClip;

    // Start is called before the first frame update
    void Start()
    {
        SpotLight.intensity = IsSpotlightOn ? 1 : 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("f"))
        {
            IsSpotlightOn = !IsSpotlightOn;
            SpotLight.intensity = IsSpotlightOn ? 2 : 0;
            AudioSource.PlayOneShot(AudioClip);
        }

    }
}
