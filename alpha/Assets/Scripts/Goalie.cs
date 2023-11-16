using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalie : MonoBehaviour
{
    public float moveDistance = 5f;
    public float defaultMoveSpeed = 2f;
    
    private Vector3 startPos;
    private bool movingRight = true;

    

    public void Awake()
    {
        Debug.Log("Awake - Initial Goalie Speed: " + defaultMoveSpeed);
    }


    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        float currentMoveSpeed = movingRight ? defaultMoveSpeed : -defaultMoveSpeed;

        transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);

        // Check if the object has moved the desired distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            // Change direction
            movingRight = !movingRight;
        }
    }


}





