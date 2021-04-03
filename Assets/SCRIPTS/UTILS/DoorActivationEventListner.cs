using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivationEventListner : Listner
{
    public DoorController doorController;
    public bool TargetLockState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnGameObjectEvent(object sender, GameBojectEventArgs e)
    {
        
        doorController.IsLockedInPosition = TargetLockState;
    }
}
