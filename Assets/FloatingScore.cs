using TMPro;
using UnityEngine;

// Ce script permet d'afficher un score flottant à l'écran (comme une animation visuelle temporaire)
public class FloatingScore : MonoBehaviour
{
    public float lifetime = 1.5f;      // Durée de vie du score flottant avant disparition
    public float floatSpeed = 1f;      // Vitesse de montée du score

    public TextMeshProUGUI scoreText;  // Référence au composant texte qui affichera le score
    private float timer;               // Chronomètre pour suivre le temps écoulé

    void Start()
    {
    }

    // Définit le score à afficher dans le texte
    public void SetScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString(); // Affiche le score sous forme de texte
    }

    void Update()
    {
        // Fait monter le score progressivement vers le haut à chaque frame
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Incrémente le temps écoulé
        timer += Time.deltaTime;

        // Si la durée de vie est atteinte, on détruit l'objet pour le faire disparaître
        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
