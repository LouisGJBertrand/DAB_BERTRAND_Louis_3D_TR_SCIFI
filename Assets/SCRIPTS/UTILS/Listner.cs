using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Listner: MonoBehaviour
{

    public abstract void OnGameObjectEvent(object sender, GameBojectEventArgs e);

}
