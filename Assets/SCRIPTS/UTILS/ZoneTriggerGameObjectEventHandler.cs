using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTriggerGameObjectEventHandler : GameObjectEventHandler
{

    public Collider TargetCollider;

    void OnTriggerEnter(Collider col)
    {
        
        if(col.GetInstanceID().Equals(TargetCollider.GetInstanceID()))
            RaiseGameObjectEventArgs(this, new GameBojectEventArgs() { });

    }

    void OnCollisionEnter(Collision other)
    {


    }

}
