using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 4.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 20.0f;
    public float rotateSpeed = 1.5f;
    public float currentSpeed = 0f;

    private Vector3 moveDirection = Vector3.zero;
    private Animator anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            currentSpeed = moveDirection.magnitude;

            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        // Rotate the controller
        transform.Rotate(0f, Input.GetAxis("Horizontal"), 0f);

        // Set the animation
        if (anim != null)
        {
            anim.SetFloat("CatSpeed", Mathf.Abs(currentSpeed),0.08f, Time.deltaTime);
        }
        else
        {
            Debug.Log("anim is null");
        }
    }
}