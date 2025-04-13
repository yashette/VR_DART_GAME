using UnityEngine;

// Ce script permet de faire bouger une cible latéralement et de la ramener à sa position d’origine lorsqu'elle ne bouge plus.
public class TargetMover : MonoBehaviour
{
    public float speed = 2f;               // Vitesse de déplacement latéral de la cible
    public float range = 1f;               // Amplitude maximale de déplacement de part et d’autre de la position initiale
    public float returnSpeed = 2f;         // Vitesse à laquelle la cible revient à sa position initiale lorsqu’elle ne bouge plus

    private Vector3 startPosition;         // Position de départ de la cible
    private bool moving = false;           // Indique si la cible est actuellement en mouvement

    // Appelée une seule fois au démarrage du script
    void Start()
    {
        // On enregistre la position de départ
        startPosition = transform.position;
    }

    // Appelée à chaque frame
    void Update()
    {
        if (moving)
        {
            // Calcul d’un déplacement latéral oscillant de type PingPong
            float offset = Mathf.PingPong(Time.time * speed, range * 2) - range;
            // Application du déplacement par rapport à la position de départ sur l’axe X (droite/gauche)
            transform.position = startPosition + Vector3.right * offset;
        }
        else
        {
            // Si la cible n’est pas à sa position d’origine, elle revient progressivement
            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            }
        }
    }

    // Permet d’alterner entre mouvement actif et inactif
    public void ToggleMovement()
    {
        moving = !moving;
    }

    // Arrête complètement le mouvement
    public void StopMovement()
    {
        moving = false;
    }

    // Retourne l’état actuel du mouvement (vrai si la cible bouge)
    public bool IsMoving()
    {
        return moving;
    }
}
