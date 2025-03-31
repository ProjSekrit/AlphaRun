using UnityEngine;
using TMPro;

public class Playscript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public int score = 0;
    private int highScore = 0;

    void Start()
    {
        // Load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void scoreup()
    {
        score++;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save new high score
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }
}

