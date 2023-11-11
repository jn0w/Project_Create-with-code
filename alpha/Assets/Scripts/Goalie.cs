using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalie : MonoBehaviour
{
    public float moveDistance = 5f;
    public float defaultMoveSpeed = 2f;
    public float speedIncreasePerGoal = 1f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
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

    public void IncreaseSpeedAndResetGame()
    {
        Debug.Log("IncreaseSpeedAndResetGame called");

        // Increase speed for the next round
        defaultMoveSpeed += speedIncreasePerGoal;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



