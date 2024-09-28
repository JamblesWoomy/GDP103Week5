using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour
{

    public GameObject Reciever;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Reciever.transform.position.x, transform.position.y, transform.position.z);
    }
}
