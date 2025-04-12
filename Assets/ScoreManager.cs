using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int initialScore;
    public TMP_Text scoreText;  // Référence au texte UI

    void Start()
    {
        SetPoints(301);
        UpdateScoreUI();
    }

    public void SoustrairePoints(int points)
    {
        int tempscore = currentScore; // Stocker le score avant la soustraction

        currentScore -= points;
        if (currentScore < 0)
            currentScore = tempscore;

        UpdateScoreUI();
    }

    public void SetPoints(int points)
    {
        currentScore = points;
        initialScore = points;

        UpdateScoreUI();
    }
    public void ResetScore()
    {
        currentScore = initialScore;     // <-- remet à zéro avec la bonne valeur
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
