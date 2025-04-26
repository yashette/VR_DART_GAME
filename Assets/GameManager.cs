using UnityEngine;
using TMPro;

[System.Serializable]
// Classe repr�sentant les donn�es d�un joueur
public class PlayerData
{
    public string playerName;  // Nom du joueur
    public int score;          // Score actuel
    public int previousScore;  // Score avant le dernier lancer (utilis� pour g�rer les busts)
}

public class GameManager : MonoBehaviour
{
    public PlayerData[] players = new PlayerData[2]; // Tableau contenant les 2 joueurs
    private int currentPlayerIndex = 0;              // Index du joueur actif (0 ou 1)

    public TMP_Text turnText;                        // Texte affichant � qui est le tour
    public TMP_Text[] scoreTexts;                    // Textes affichant les scores des deux joueurs

    public GameObject nextPlayerButton;              // Bouton pour passer au joueur suivant (affich� en fin de tour)
    public TMP_Text bustText;                        // Message affich� en cas de "bust" (d�passement de score)

    private int currentStartingScore = 301;         // Score de d�part (modifiable)
    public HapticFeedback haptic;                   // HapticManager pour la vibration

    private void Start()
    {
        // Initialisation des deux joueurs avec un score de d�part de 301
        players[0] = new PlayerData { playerName = "Player 1", score = 301 };
        players[1] = new PlayerData { playerName = "Player 2", score = 301 };

        // On cache le texte de bust au d�marrage
        bustText.gameObject.SetActive(false);

        // On met � jour l�affichage
        UpdateUI();
    }

    // Permet de d�finir un nouveau score de d�part
    public void SetStartingScore(int score)
    {
        currentStartingScore = score;
        // R�initialisation des scores des joueurs
        players[0].score = score;
        players[1].score = score;
        players[0].previousScore = score;
        players[1].previousScore = score;
        // Le jeu reprend avec le joueur 1
        currentPlayerIndex = 0;
        bustText.gameObject.SetActive(false);
        UpdateUI();

        haptic.TriggerHaptic(); // on fait vibrer la manette
    }

    // R�initialise compl�tement le jeu avec le score de d�part actuel
    public void ResetGame()
    {
        SetStartingScore(currentStartingScore); 
    }

    // Enregistre les points d�un lancer pour le joueur courant
    public void RegisterThrow(int points)
    {
        PlayerData current = players[currentPlayerIndex];

        // Sauvegarde du score actuel avant de le modifier
        current.previousScore = current.score; // on sauvegarde avant de modifier

        int projectedScore = current.score - points;

        if (projectedScore < 0)
        {
            // Si le joueur d�passe 0, c�est un "bust", on restaure l�ancien score
            current.score = current.previousScore;
            bustText.gameObject.SetActive(true);
            AudioManager.Instance.PlayClip(AudioManager.Instance.bustClip);
        }
        else
        {
            bustText.gameObject.SetActive(false);
            current.score = projectedScore;

            // Si le score atteint exactement 0, le joueur gagne
            if (projectedScore == 0)
            {
                EndGame();
                return;
            }
        }

        // Fin du tour : on attend que le joueur clique sur "Next Player"
        nextPlayerButton.SetActive(true);
        UpdateUI();
    }

    // Passe au joueur suivant
    public void NextPlayer()
    {
        bustText.gameObject.SetActive(false);
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        AudioManager.Instance.PlayClip(AudioManager.Instance.nextPlayerClip);
        UpdateUI();
        haptic.TriggerHaptic();
    }

    // Affiche le message de fin de jeu
    void EndGame()
    {
        turnText.text = $"{players[currentPlayerIndex].playerName} won !";

        if (players[currentPlayerIndex].playerName == "Player 1")
        {
            AudioManager.Instance.PlayClip(AudioManager.Instance.victoryP1Clip);
        }
        else
        {
            AudioManager.Instance.PlayClip(AudioManager.Instance.victoryP2Clip);
        }

    }

    // Met � jour l�interface (tour actuel + scores)
    void UpdateUI()
    {
        turnText.text = $"{players[currentPlayerIndex].playerName}'s turn";

        scoreTexts[0].text = $"Player 1 : {players[0].score}";
        scoreTexts[1].text = $"Player 2 : {players[1].score}";
    }
}
