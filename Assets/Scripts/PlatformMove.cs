using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Animator animator;
    public string playerTag = "Player";
    public string ragTag = "Ragdoll";
    public Transform platform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag) || other.gameObject.tag.Equals(ragTag))
        {
            other.gameObject.transform.parent = platform;
        }
        animator.SetBool("PlatformMove", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("PlatformMove", false);
        animator.SetTrigger("HasWent");
    }
}