using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance; // Singleton instance

    private Vector3 initialBallPosition; // Store initial ball position
    private GameObject ballObject; // Reference to the current ball object
    private float initialBallSpeed;

    private void Awake(){
        Instance = this;
        initialBallPosition = transform.position; // Store initial position on Awake

    }

    public void SetBallObject(GameObject ball){
        ballObject = ball;
        initialBallSpeed = ballObject.GetComponent<Rigidbody>().velocity.magnitude;

    }

    public void DestroyBallObject(){

        if (ballObject != null){
            Destroy(ballObject);

        }

    }

    public void ResetBallPosition(){
        // Reset ball position to its initial position
        transform.position = initialBallPosition;
        // Reset any other ball attributes as needed
        if (ballObject != null){
            Rigidbody ballRigidbody = ballObject.GetComponent<Rigidbody>();
            ballRigidbody.velocity = ballRigidbody.velocity.normalized * initialBallSpeed;

        }

    }

    public GameObject GetBallObject(){
        return ballObject;

    }

}
