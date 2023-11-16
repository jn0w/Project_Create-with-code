using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public Goalie goalkeeper;
    public TextMeshProUGUI Score;
    private int score = 0;

    public float defaultMoveSpeed = 2f;
    public float speedIncreasePerGoal = 5f;

    public GameObject ballPrefab; // Reference to the new ball prefab
    public Transform ballSpawnPoint; // Transform where the new ball spawns

    public GameObject ballObject; // Reference to your Ball object
    private BallManager ballManager;
    public PlayerController playerController;

    private void Start()
    {
        goalkeeper = FindObjectOfType<Goalie>();
        ballManager = FindObjectOfType<BallManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            IncreaseSpeed();
            IncreaseScore();
            UpdateScoreText();
            ResetGame();
        }
    }

    public void IncreaseSpeed()
    {
        // Increase speed for the next round
        defaultMoveSpeed += speedIncreasePerGoal;

        // Log the speed increase for debugging
        Debug.Log("Goalie speed increased to: " + defaultMoveSpeed);
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void UpdateScoreText()
    {
        if (Score != null)
        {
            Score.text = "Score: " + score.ToString(); // Update the TextMeshProUGUI with the current score
        }
    }

    public void ResetGame()
    {
        // Reset the ball position
        ballManager.ResetBallPosition();

        // Destroy the current ball
        ballManager.DestroyBallObject();

        // Spawn a new ball
        SpawnNewBall();
        
        // Reset the player position
        playerController.ResetPlayerPosition();
        // You might also need to reset any other game-specific states or objects here
    }

    private void SpawnNewBall()
    {
        // Instantiate a new ball at the specified spawn point
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ballManager.SetBallObject(newBall); // Set the new ball object in the BallManager
    }
}
