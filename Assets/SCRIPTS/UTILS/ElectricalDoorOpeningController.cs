using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalDoorOpeningController : Listner
{
    public DoorController doorController;
    public bool TargetLockState = false;

    bool dialogueStarted = false;
    float DialogTimePassed = 0;

    public List<Light> CorridorsAlarmLights;

    public int dialogueLine = 0;

    public CaptionController CaptionController;

    void ShutCorridorsAlarmLights()
    {

        foreach (Light light in CorridorsAlarmLights)
        {

            light.enabled = false;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueStarted)
            DialogTimePassed += Time.deltaTime;

        if(dialogueStarted && dialogueLine == 0 && DialogTimePassed > 0)
        {
            CaptionController.ShowCaption("- You : \"The closest door to the dock is broken...", Color.white, 5, TextAnchor.MiddleLeft);
            dialogueLine++;
        }

        if (dialogueStarted && dialogueLine == 1 && DialogTimePassed > 6)
        {
            CaptionController.ShowCaption("\"I will have to take the long route...", Color.white, 5, TextAnchor.MiddleLeft);
            dialogueLine++;
        }

        if (dialogueStarted && dialogueLine == 2 && DialogTimePassed > 12)
        {
            CaptionController.ShowCaption("\"I've disabled the rotating lights...", Color.white, 5, TextAnchor.MiddleLeft);
            ShutCorridorsAlarmLights();
            dialogueLine++;
        }

        if (dialogueStarted && dialogueLine == 3 && DialogTimePassed > 18)
        {
            CaptionController.ShowCaption("\"They are annoying to lookat.\"", Color.white, 5, TextAnchor.MiddleLeft);
            dialogueLine++;
        }


    }
    public override void OnGameObjectEvent(object sender, GameBojectEventArgs e)
    {
        dialogueStarted = true;
        doorController.IsLockedInPosition = TargetLockState;
    }
}
