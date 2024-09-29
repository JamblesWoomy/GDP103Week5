using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour //plays the moving platform's animation when the player interacts with it
{
    public Animator animator;
    public string playerTag = "Player";
    public string ragTag = "Ragdoll";
    public Transform platform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag) || other.gameObject.tag.Equals(ragTag))
        {
            other.gameObject.transform.parent = platform; // makes sure the player moves along with the platform when it starts moving
        }
        animator.SetBool("PlatformMove", true); //play animation
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("PlatformMove", false);//make sure animation stops when player exits collider
        animator.SetTrigger("HasWent");//sets animation to return trip
    }
}