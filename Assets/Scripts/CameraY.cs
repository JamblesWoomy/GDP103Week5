using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour // Controls camera top down movement so it follows the player's movement
{

    public GameObject Reciever;//what the camera follows
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Reciever.transform.position.x, Reciever.transform.position.y+10, Reciever.transform.position.z);
    }
}
