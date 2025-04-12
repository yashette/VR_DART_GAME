using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float speed = 2f;               // vitesse de déplacement latéral
    public float range = 1f;               // distance max de chaque côté
    public float returnSpeed = 2f;         // vitesse de retour à la position d'origine

    private Vector3 startPosition;         // position de départ
    private bool moving = false;           // cible mobile ou non
    private float direction = 1f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            float offset = Mathf.PingPong(Time.time * speed, range * 2) - range;
            transform.position = startPosition + Vector3.right * offset;
        }
        else
        {
            // Retour progressif à la position initiale
            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            }
        }
    }

    public void ToggleMovement()
    {
        moving = !moving;
    }

    public void StopMovement()
    {
        moving = false;
    }

    public bool IsMoving()
    {
        return moving;
    }
}
