using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Listner Listner;
    
    public GameObjectEventHandler Trigger;

    public void Start()
    {
        Trigger.GameObjectEvent += Listner.OnGameObjectEvent;
    }

    public void Update()
    {

    }

}
