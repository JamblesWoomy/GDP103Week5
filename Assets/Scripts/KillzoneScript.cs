using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        var ragdoller = other.gameObject.GetComponent<RagdollEffect>();
        if (ragdoller != null)
        {
            ragdoller.RagdollOn();
        }
    }
}
