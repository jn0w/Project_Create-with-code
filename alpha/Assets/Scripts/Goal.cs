using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Goalie goalkeeper;

    public void Start()
    {
        goalkeeper = FindObjectOfType<Goalie>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Assuming the ball is tagged as "Ball"
        {
            // Ball touched the goal area
            goalkeeper.IncreaseSpeedAndResetGame();
        }
    }
}

