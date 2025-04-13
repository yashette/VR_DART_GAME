using UnityEngine;

// Ce script permet de faire bouger une cible lat�ralement et de la ramener � sa position d�origine lorsqu'elle ne bouge plus.
public class TargetMover : MonoBehaviour
{
    public float speed = 2f;               // Vitesse de d�placement lat�ral de la cible
    public float range = 1f;               // Amplitude maximale de d�placement de part et d�autre de la position initiale
    public float returnSpeed = 2f;         // Vitesse � laquelle la cible revient � sa position initiale lorsqu�elle ne bouge plus

    private Vector3 startPosition;         // Position de d�part de la cible
    private bool moving = false;           // Indique si la cible est actuellement en mouvement

    // Appel�e une seule fois au d�marrage du script
    void Start()
    {
        // On enregistre la position de d�part
        startPosition = transform.position;
    }

    // Appel�e � chaque frame
    void Update()
    {
        if (moving)
        {
            // Calcul d�un d�placement lat�ral oscillant de type PingPong
            float offset = Mathf.PingPong(Time.time * speed, range * 2) - range;
            // Application du d�placement par rapport � la position de d�part sur l�axe X (droite/gauche)
            transform.position = startPosition + Vector3.right * offset;
        }
        else
        {
            // Si la cible n�est pas � sa position d�origine, elle revient progressivement
            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            }
        }
    }

    // Permet d�alterner entre mouvement actif et inactif
    public void ToggleMovement()
    {
        moving = !moving;
    }

    // Arr�te compl�tement le mouvement
    public void StopMovement()
    {
        moving = false;
    }

    // Retourne l��tat actuel du mouvement (vrai si la cible bouge)
    public bool IsMoving()
    {
        return moving;
    }
}
