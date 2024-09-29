using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEffect : MonoBehaviour
{
    public bool xPressed = false;
    private Animator animator;
    public GameObject ragdoll;
    public void RagdollOn()
    {
        if (xPressed == true)
        {
            Debug.Log("RagdollOff");
            animator.enabled = true;
            xPressed = false;
        } else
        {
            Debug.Log("RagdollOn");
            animator.enabled = false;
            xPressed = true;
        }
    }
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 7);
        Physics.IgnoreLayerCollision(6, 7);
        StartCoroutine("RagdollTimer");
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //On SPACE turn on the ragdoll.
        if (Input.GetKeyDown(KeyCode.X))
        {
            RagdollOn();
        }
    }

    private IEnumerator RagdollTimer()
    {
        yield return new WaitForSeconds(0.2f); // wait two minutes
        Debug.Log("Jiggy");
        ragdoll.SetActive(true);
    }

}
