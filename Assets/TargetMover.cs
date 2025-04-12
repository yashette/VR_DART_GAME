using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float speed = 2f;               // vitesse de d�placement lat�ral
    public float range = 1f;               // distance max de chaque c�t�
    public float returnSpeed = 2f;         // vitesse de retour � la position d'origine

    private Vector3 startPosition;         // position de d�part
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
            // Retour progressif � la position initiale
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
