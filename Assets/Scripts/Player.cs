using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private Vector2 moveInput;
    private CharacterController characterController;
    public float moveSpeed = 5f;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) *
        moveSpeed * Time.deltaTime;
        characterController.Move(move);
        // Update the animator with the movement speed
        animator.SetFloat("velocityX", moveInput.x * moveSpeed);
        animator.SetFloat("velocityY", moveInput.y * moveSpeed);
    }
    // Method to handle the Clap action started
    public void OnFall(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("fall", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("fall", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}