using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);

        highScoreText.text = $"High Score: {highScore:F2} m";
    }
}