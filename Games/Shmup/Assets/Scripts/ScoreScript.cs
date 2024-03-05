using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public static ScoreScript S;

    void Awake()   // Singleton
    {
        S = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(1);
        }

    }

    public void AddScore(int value)
    {
        score += value;
        string scoreDisplay = "Score: " + score.ToString();
        scoreText.text = scoreDisplay;
    }
}
