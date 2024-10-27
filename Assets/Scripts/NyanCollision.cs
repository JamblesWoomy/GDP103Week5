using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCollision : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    private bool runOnce = false;

    void Awake()
    {
        // Get the Animator component attached to the same GameObject
        animator = player.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider cole)
    {
        Debug.Log("Collision");
        if (!runOnce)
        {
            player.GetComponent<Player>().enabled = false;
            animator.SetTrigger("Fall");
            runOnce = true;
            return;
        } else
        {
            reset();
        }
    }

    private void reset()
    {
        Debug.Log("False");
        //animator.SetBool("Fall", false);
        Destroy(this);
    }
}