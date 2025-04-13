using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int score;
    public int previousScore;
}

public class GameManager : MonoBehaviour
{
    public PlayerData[] players = new PlayerData[2];
    private int currentPlayerIndex = 0;

    public TMP_Text turnText;
    public TMP_Text[] scoreTexts;

    public GameObject nextPlayerButton; // à afficher seulement en fin de tour
    public TMP_Text bustText;

    private int currentStartingScore = 301;

    private void Start()
    {
        players[0] = new PlayerData { playerName = "Player 1", score = 301 };
        players[1] = new PlayerData { playerName = "Player 2", score = 301 };

        bustText.gameObject.SetActive(false);


        UpdateUI();
    }
    public void SetStartingScore(int score)
    {
        currentStartingScore = score; 
        players[0].score = score;
        players[1].score = score;
        players[0].previousScore = score;
        players[1].previousScore = score;
        currentPlayerIndex = 0;
        bustText.gameObject.SetActive(false);
        UpdateUI();
    }

    public void ResetGame()
    {
        SetStartingScore(currentStartingScore); 
    }


    public void RegisterThrow(int points)
    {
        PlayerData current = players[currentPlayerIndex];

        current.previousScore = current.score; // on sauvegarde avant de modifier

        int projectedScore = current.score - points;

        if (projectedScore < 0)
        {
            // Bust on restaure l'ancien score
            current.score = current.previousScore;
            bustText.gameObject.SetActive(true);
        }
        else
        {
            bustText.gameObject.SetActive(false);
            current.score = projectedScore;

            if (projectedScore == 0)
            {
                EndGame();
                return;
            }
        }

        // Fin du tour  on attend que le joueur appuie sur le bouton
        nextPlayerButton.SetActive(true);
        UpdateUI();
    }

    public void NextPlayer()
    {
        bustText.gameObject.SetActive(false);
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        UpdateUI();
    }

    void EndGame()
    {
        turnText.text = $"{players[currentPlayerIndex].playerName} won !";
    }

    void UpdateUI()
    {
        turnText.text = $"Tour of : {players[currentPlayerIndex].playerName}";

        scoreTexts[0].text = $"Player 1 : {players[0].score}";
        scoreTexts[1].text = $"Player 2 : {players[1].score}";
    }
}
