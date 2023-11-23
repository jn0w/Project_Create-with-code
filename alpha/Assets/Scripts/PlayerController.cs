using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem  jumpParticles;

    

    private Vector3 initialPlayerPosition; // Store initial player position
    

   
    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = transform.position;
        
    }

    //private variables
    public  float speed = 10;
    public float jumpForce = 10f;
    private bool isGrounded;

    private float horizontalInput;
    private float forwardInput;
    // Update is called once per frame
    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontalInput, 0f,forwardInput) * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        jumpParticles.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void ResetPlayerPosition()
    {
        // Reset player position to its initial position
        transform.position = initialPlayerPosition;
        // You might also need to reset the player's state or any other attributes here
    }
}
