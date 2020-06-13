using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 10f;
    public bool isGrounded;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    void FixedUpdate()
    {

        if (isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
