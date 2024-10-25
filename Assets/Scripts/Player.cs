using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour //controls all player input events and animations
{
    private Animator animator;
    private Vector2 moveInput;
    private CharacterController characterController;
    private Vector3 direction;

    [SerializeField] private float smoothTime = 0.05f;
    private float currentVelocity; //the players given speed at any point

    [SerializeField] private float moveSpeed;

    private float gravity = -9.81f;//controls gravity systems so the player can fall if needed
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float velocity;
    private bool crouchOn;

    [SerializeField]
    private Guns gun;

    void Awake()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        animator.SetFloat("velocityX", moveInput.x * moveSpeed);//make sure the animation corresponds with movement
        animator.SetFloat("velocityY", moveInput.y * moveSpeed);
    }
    private void ApplyGravity()// applies gravity
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

    private void ApplyRotation()//makes sure the player model roatates when going in certain directions
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
    private void ApplyMovement()//the player's movment is dependent on the direction and speed
    {
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }

    public void OnFlair(InputAction.CallbackContext context)//plays the taunt animation when the Z button is pressed
    {
        if (context.started)
        {
            animator.SetBool("Taunt", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("Taunt", false);
        }
    }

    public void Crouch(InputAction.CallbackContext context)// puts the player in the crouching state with new idle and walking animations
    {
        crouchOn = !crouchOn;//makes sure the crouching animations are toggled
        if (context.started && crouchOn == true)
        {
            Debug.Log("Crouch");
            animator.SetBool("Crouch", true);
            moveSpeed = moveSpeed / 2;
        }
        else if (context.canceled && crouchOn == false)
        {
            animator.SetBool("Crouch", false);
            moveSpeed = moveSpeed * 2;
        }
    }

    public void Sprint(InputAction.CallbackContext context)// changes the player's walking and idle animations and increases the movement speed
    {
        if (context.started)
        {
            moveSpeed = moveSpeed * 2;
            animator.SetBool("Sprint", true);
        }
        else if (context.canceled)
        {
            moveSpeed = moveSpeed / 2;
            animator.SetBool("Sprint", false);
        }
    }
    
    public void OnShoot(InputAction.CallbackContext context)// changes the player's walking and idle animations and increases the movement speed
    {
        gun.Shoot();
        /*if (context.started)
        {
            moveSpeed = moveSpeed * 2;
            animator.SetBool("Sprint", true);
        }
        else if (context.canceled)
        {
            moveSpeed = moveSpeed / 2;
            animator.SetBool("Sprint", false);
        }*/
    }

    public void OnMove(InputAction.CallbackContext context)//processes the player's movement based on the WASD input
    {
        moveInput = context.ReadValue<Vector2>();
        direction = new Vector3(moveInput.x, 0.0f, moveInput.y);
    }

    private bool IsGrounded() => characterController.isGrounded;//checks to make sure the player is grounded and beomces ungrounded when falling
}