using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float currentScore;

    void Update()
    {
        // Player starts at Y = 6 and falls downward
        currentScore = player.position.y;

        scoreText.text = $"Score: {currentScore:F2} m";

        float finalScore = (6f - player.position.y) / 100f;

        float previousHighScore = PlayerPrefs.GetFloat("HighScore", 0);

            if (finalScore > previousHighScore)
            {
                PlayerPrefs.SetFloat("HighScore", finalScore);
            }

                PlayerPrefs.Save();
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    
}

//