using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotLightController : MonoBehaviour
{

    public Light SpotLight;
    public bool IsSpotlightOn = false;
    public AudioSource AudioSource;
    public AudioClip AudioClip;

    public bool IsAffectedByBatery = true;
    public float InitialBateryLeft = 100;
    public float MinBatery = 0;
    public float MaxBatery = 100;
    public float BateryLeft = 0;

    public float BateryDischargeIntesityMultiplier = 1;
    public float BateryRechargeIntesityMultiplier = 0.5f;

    public bool IsLightIntensityAffectedByBatery = true;

    public Text CaptionTextObject;

    // Start is called before the first frame update
    void Start()
    {
        SpotLight.intensity = IsSpotlightOn ? 1 : 0;

        BateryLeft = InitialBateryLeft;
    }

    // Update is called once per frame
    void Update()
    {

        CaptionTextObject.text = "🔦 " + (int)BateryLeft + "%";

        if (Input.GetKeyDown("f"))
        {
            IsSpotlightOn = !IsSpotlightOn;
            AudioSource.PlayOneShot(AudioClip);
        }

        if( IsSpotlightOn )
        {

            BateryLeft -= BateryLeft > MinBatery ? Time.deltaTime * BateryDischargeIntesityMultiplier : MinBatery;
            if (BateryLeft <= MinBatery)
            {
                BateryLeft = MinBatery;
            }

        }
        else
        {
            BateryLeft += BateryLeft < MaxBatery ? Time.deltaTime * BateryRechargeIntesityMultiplier : MaxBatery;
            if (BateryLeft >= MaxBatery)
            {
                BateryLeft = MaxBatery;
            }
        }

        if(BateryLeft <= MinBatery)
        {
            IsSpotlightOn = false;
            AudioSource.PlayOneShot(AudioClip);
        }

        SpotLight.intensity = IsSpotlightOn ? 2 * (IsLightIntensityAffectedByBatery ? BateryLeft / MaxBatery : 1.0f) : 0;

    }
}
