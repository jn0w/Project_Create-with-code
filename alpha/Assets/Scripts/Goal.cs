using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public Button restartButton;
    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    public float timeValue;
    private bool ballScored = false;

    private void Start()
    {
        goalkeeper = FindObjectOfType<Goalie>();
        ballManager = FindObjectOfType<BallManager>();
        playerController = FindObjectOfType<PlayerController>();
        isGameActive = true;
        timeValue = 60;
        Time.timeScale = 1f;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartButtonClick);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !ballScored)
        {
            ballScored = true; // Set the flag to true when the ball is scored

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
        // Reset the ball position only if the ball has been scored
        if (ballScored)
        {
            ballManager.ResetBallPosition();
            ballScored = false; // Reset the flag
        }

        playerController.ResetPlayerPosition();

        // Reset other game-specific states or objects here
    }

    private void SpawnNewBall()
    {
        // Instantiate a new ball at the specified spawn point
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ballManager.SetBallObject(newBall); // Set the new ball object in the BallManager
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0f;
        
    }

    public void Update(){

        if (isGameActive == true){

            TimeLeft();

        }

        if (timeValue < 0){

            GameOver();

        }

    }

    private void TimeLeft()
    {
        if (timeText != null)
        {
            timeValue -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(timeValue);
        }
    }

    private void RestartButtonClick()
    {
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        
    }

}
