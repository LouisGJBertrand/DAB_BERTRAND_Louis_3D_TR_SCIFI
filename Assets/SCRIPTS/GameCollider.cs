using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollider : MonoBehaviour
{

    public GameObject CubeCollider = null;

    [SerializeField]
    private Vector3 colliderSize;
    public Vector3 ColliderSize
    {
        get { return colliderSize; }
        set { CubeCollider.transform.localScale = ColliderSize; colliderSize = ColliderSize; }
    }

}
