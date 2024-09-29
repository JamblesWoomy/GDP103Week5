using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour //controls all the ragdoll events in the scene, including the toggling between ragdoll and animated states and making sure the animations are unaffected by the ragdoll
{
    public bool xPressed = false;
    private Animator animator;
    public GameObject ragdoll;
    public void RagdollOn()
    {
        if (xPressed == true)// lets the player toggle the ragdoll state on and off so they can switch between animations and ragdoll physics
        {
            animator.enabled = true;
            xPressed = false;
        } else
        {
            animator.enabled = false;
            xPressed = true;
        }
    }
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 7);//makes sure none of the ragdoll components clash with one another
        Physics.IgnoreLayerCollision(6, 7);
        StartCoroutine("RagdollTimer");//after two frames, the ragdoll will be shown without conflicting
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //On SPACE turn on the ragdoll.
        if (Input.GetKeyDown(KeyCode.X))
        {
            RagdollOn();//turns the player model into a ragdoll on X key input
        }
    }

    private IEnumerator RagdollTimer()//initially hides then shows the ragdoll components 
    {
        yield return new WaitForSeconds(0.2f); // wait two frames
        ragdoll.SetActive(true);
    }

}
