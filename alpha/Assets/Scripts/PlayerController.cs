using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem  jumpParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private variables
    public  float speed = 10;
    public float jumpForce = 10f;

    private float horizontalInput;
    private float forwardInput;
    // Update is called once per frame
    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontalInput, 0f,forwardInput) * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        jumpParticles.Play();
    }
}
