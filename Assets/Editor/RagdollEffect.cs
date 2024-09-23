using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    private Animator animator;
    public void RagdollOn()
    {
        animator.enabled = false;
    }
    void Start()
    {
        Physics.IgnoreLayerCollision(6,7,true);
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
