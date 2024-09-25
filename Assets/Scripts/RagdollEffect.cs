using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    public bool spacePressed = false;
    private Animator animator;
    public void RagdollOn()
    {
        if (spacePressed == true)
        {
            animator.enabled = true;
            spacePressed = true;
        } else
        {
            animator.enabled = false;
            spacePressed = false;
        }
    }
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 7);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //On SPACE turn on the ragdoll.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RagdollOn();
        }
    }
}
