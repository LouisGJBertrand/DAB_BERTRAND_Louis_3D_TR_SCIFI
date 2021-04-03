using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelController : MonoBehaviour
{

    public List<Light> GarageLightsA;
    public List<Light> GarageLightsB;
    public List<Light> GarageLightsC;
    public List<Light> AlertLights;

    public CameraFade CameraFade;

    public static bool ArePlayerControlsLocked;
    public bool ArePlayerControlsLockedValue;
    public float timePassed;
    public Text CaptionText;

    public CaptionController CaptionController;
    public int ReadOnlyLastDisplayedCaption;
    private int LastDisplayedCaption;

    public Transform GarageDoorTransform;
    public void ToggleUserControls()
    {
        ArePlayerControlsLocked = !ArePlayerControlsLocked;
    }

    // Start is called before the first frame update
    void Start()
    {
        ArePlayerControlsLocked = ArePlayerControlsLockedValue;

        foreach (Light light in GarageLightsA)
        { light.enabled = false; }
        foreach (Light light in GarageLightsB)
        { light.enabled = false; }
        foreach (Light light in GarageLightsC)
        { light.enabled = false; }
        foreach (Light light in AlertLights)
        { light.enabled = false; }

        CameraFade.speedScale = 0.1f;
        CameraFade.FadeIn();

        CaptionText.text = "[Alarm Sounds]";

    }

    // Update is called once per frame
    void Update()
    {
        ArePlayerControlsLockedValue = ArePlayerControlsLocked;


        if (timePassed < 4 && LastDisplayedCaption != 1)
        {

            CaptionController.ShowCaption("[Alarm Sounds]", Color.yellow, 4, TextAnchor.MiddleCenter);
            LastDisplayedCaption = 1;

        }
        else
        if (timePassed >= 5 && timePassed <= 8 && LastDisplayedCaption != 2)
        {
            CaptionController.ShowCaption(" - Alarm voice: \"Alert Raised...", Color.yellow, 3, TextAnchor.MiddleCenter);
            LastDisplayedCaption = 2;
        }
        else
        if (timePassed >= 9 && timePassed <= 13 && LastDisplayedCaption != 3)
        {
            CaptionController.ShowCaption(" - \"Head toward the bridge for extraction.\"", Color.yellow, 3, TextAnchor.MiddleCenter);
            LastDisplayedCaption = 3;
        }
        else
        if (timePassed >= 14 && timePassed <= 19 && LastDisplayedCaption != 4)
        {
            CaptionController.ShowCaption(" - You: \"The door will be locked but i need to get out...", Color.white, 3, TextAnchor.MiddleLeft);
            LastDisplayedCaption = 4;
        }
        else
        if (timePassed >= 20 && timePassed <= 25 && LastDisplayedCaption != 5)
        {
            CaptionController.ShowCaption(" - \"The security system locks every doors, i will have to reactivate them.\"", Color.white, 3, TextAnchor.MiddleLeft);
            LastDisplayedCaption = 5;

        }


        if (timePassed >= 10 && !GarageLightsA[0].enabled)
        {

            foreach (Light light in GarageLightsA)
            { light.enabled = true; }

        }
        if (timePassed >= 11 && !GarageLightsB[0].enabled)
        {

            foreach (Light light in GarageLightsB)
            { light.enabled = true; }

        }
        if (timePassed >= 12 && !GarageLightsC[0].enabled)
        {

            foreach (Light light in GarageLightsC)
            { light.enabled = true; }

        }
        if (timePassed >= 20 && !AlertLights[0].enabled)
        {

            foreach (Light light in AlertLights)
            { light.enabled = true; }

            ToggleUserControls();
        }

        timePassed += Time.deltaTime;

    }
}
