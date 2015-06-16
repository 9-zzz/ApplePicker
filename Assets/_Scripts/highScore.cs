using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScore : MonoBehaviour
{
    public static int hScore = 0;
    public static Text highScoreText;
    public int score;

    // Use this for initialization
    void Awake()
    {
        highScoreText = GetComponent<Text>();

        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        { // 2
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        // Assign the high score to ApplePickerHighScore
        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        if (score > hScore)
        {
            hScore = score;
        }
        highScoreText.text = "HIGH SCORE: " + hScore;

        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }

}