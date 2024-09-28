using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour
{

    public GameObject Reciever;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Reciever.transform.position.x, Reciever.transform.position.y+10, Reciever.transform.position.z);
    }
}
