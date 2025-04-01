using UnityEngine;
using TMPro;

public class Playscript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public int score = 0;
    private int highScore = 0;

private bool isReady = false;

void Start()
{
    score = 0;
    UpdateUI();
    highScore = PlayerPrefs.GetInt("HighScore", 0);
    UpdateUI();

    isReady = true;
}

public void scoreup()
{
    if (!isReady) return; // 🛑 Ignore early calls

    score++;
    if (score > highScore)
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    UpdateUI();
}


    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High_Score: " + highScore;
    }
}

