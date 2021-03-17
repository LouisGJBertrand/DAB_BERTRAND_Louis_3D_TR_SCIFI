using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEventHandler : MonoBehaviour
{

    public EventHandler<GameBojectEventArgs> GameObjectEvent;

    public void RaiseGameObjectEventArgs (object sender, GameBojectEventArgs e)
    {

        var TMP_Event = GameObjectEvent;
        if(TMP_Event != null)
        {
            var RaiseEvent = TMP_Event;
            RaiseEvent(sender, e);
            return;
        }
        return;

    }

}
