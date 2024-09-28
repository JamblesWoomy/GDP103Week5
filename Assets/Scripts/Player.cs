using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private Vector2 moveInput;
    private CharacterController characterController;
    private Vector3 direction;

    [SerializeField] private float smoothTime = 0.05f;
    private float currentVelocity;

    [SerializeField] private float moveSpeed;

    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float velocity;

    void Awake()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        /*Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) *
        moveSpeed * Time.deltaTime;
        characterController.Move(move);*/
        // Update the animator with the movement speeeeeee
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        animator.SetFloat("velocityX", moveInput.x * moveSpeed);
        animator.SetFloat("velocityY", moveInput.y * moveSpeed);
    }
    private void ApplyGravity()
    {
        if (IsGrounded())
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        direction.y = velocity;
    }

    private void ApplyRotation()
    {
        if (moveInput.sqrMagnitude == 0)
        {
            animator.SetFloat("velocityX", 0);
            animator.SetFloat("velocityY", 0);
            return;
        }
        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
    }
    private void ApplyMovement()
    {
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }

    // Method to handle the Clap action started
    public void OnFlair(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("Flair", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("Flair", false);
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        Debug.Log("Crouch");
        if (context.started)
        {
            animator.SetBool("Crouch", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("Crouch", false);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        direction = new Vector3(moveInput.x, 0.0f, moveInput.y);
    }

    private bool IsGrounded() => characterController.isGrounded;
}