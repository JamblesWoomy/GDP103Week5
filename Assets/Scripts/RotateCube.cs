using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour //script for the rotating joke cube
{
    public Vector3 rotate;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);// rotates along the vector3 values
    }
}
