using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    void Start()
    {
        Debug.Log("scripts workin");
        Physics.IgnoreLayerCollision(6, 7);
    }
}
