using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 301; // Score initial
    public TMP_Text scoreText;  // Référence au texte UI

    void Start()
    {
        UpdateScoreUI();
    }

    public void SoustrairePoints(int points)
    {
        int tempscore = score; // Stocker le score avant la soustraction

        score -= points;
        if (score < 0)
            score = tempscore;

        UpdateScoreUI();
    }

    public void SetPoints(int points)
    {
            score = points;

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
