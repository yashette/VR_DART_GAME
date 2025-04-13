using TMPro;
using UnityEngine;

// Ce script permet d'afficher un score flottant � l'�cran (comme une animation visuelle temporaire)
public class FloatingScore : MonoBehaviour
{
    public float lifetime = 1.5f;      // Dur�e de vie du score flottant avant disparition
    public float floatSpeed = 1f;      // Vitesse de mont�e du score

    public TextMeshProUGUI scoreText;  // R�f�rence au composant texte qui affichera le score
    private float timer;               // Chronom�tre pour suivre le temps �coul�

    void Start()
    {
    }

    // D�finit le score � afficher dans le texte
    public void SetScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString(); // Affiche le score sous forme de texte
    }

    void Update()
    {
        // Fait monter le score progressivement vers le haut � chaque frame
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Incr�mente le temps �coul�
        timer += Time.deltaTime;

        // Si la dur�e de vie est atteinte, on d�truit l'objet pour le faire dispara�tre
        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
