using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoorScript : MonoBehaviour
{

    public DoorController DoorController;
    public bool PreviousDoorLockState;
    public Color UnlockedColor;
    public Color LockedColor;
    public List<Light> Lights;

    // Start is called before the first frame update
    void Start()
    {
        if (DoorController.IsLockedInPosition)
        {
            foreach (Light light in Lights)
            {
                light.color = LockedColor;
            }
        }
        else
        {
            foreach (Light light in Lights)
            {
                light.color = UnlockedColor;
            }
        }
        PreviousDoorLockState = DoorController.IsLockedInPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (PreviousDoorLockState == DoorController.IsLockedInPosition)
            return;

        if (DoorController.IsLockedInPosition)
        {
            foreach(Light light in Lights)
            {
                light.color = LockedColor;
            }
        }
        else
        {
            foreach (Light light in Lights)
            {
                light.color = UnlockedColor;
            }
        }

        PreviousDoorLockState = DoorController.IsLockedInPosition;
    }
}
