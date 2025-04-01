using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartThrow : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    private Vector3 lastPosition;
    private Vector3 velocity;
    private XRGrabInteractable grabInteractable;

    public Transform pointHP;  // Pointe de la fléchette (avant)
    public Transform flightHP; // Ailette (arrière)
    public float throwForceMultiplier = 5f; // Force du lancer
    public float rotationSmoothness = 15f; // Vitesse d'alignement

    public Quaternion respawnRotation = Quaternion.Euler(0, 0, 0); // Rotation fixe après réapparition

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        rb.isKinematic = true; // Empêcher la gravité au début

        // Associer les événements de grab
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if (isHeld)
        {
            // Calculer la vitesse de déplacement uniquement sur l'axe horizontal
            Vector3 currentPosition = transform.position;
            velocity = (currentPosition - lastPosition) / Time.deltaTime;
            lastPosition = currentPosition;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        lastPosition = transform.position;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;

        // Désactiver isKinematic AVANT d'appliquer la vélocité
        rb.isKinematic = false;
        rb.useGravity = false;

        // Attendre une frame pour éviter l'erreur de kinematic
        StartCoroutine(ApplyThrowVelocity());

        // Démarrer le processus de disparition et de réapparition
        StartCoroutine(DestroyAndRespawnDart());
    }

    private IEnumerator ApplyThrowVelocity()
    {
        yield return null; // Attendre une frame pour que isKinematic soit bien désactivé

        Vector3 throwDirection = velocity.normalized;
        throwDirection.y = 0; // Bloquer le mouvement vertical

        rb.velocity = throwDirection * throwForceMultiplier;
        rb.angularVelocity = Vector3.zero; // Empêcher toute rotation involontaire

        Debug.Log("DartThrow: Vitesse appliquée au lancer -> " + rb.velocity);

        AlignDartHorizontally();
        StartCoroutine(ApplyGravitySmoothly());
    }

    private IEnumerator ApplyGravitySmoothly()
    {
        float duration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rb.AddForce(Vector3.down * (elapsedTime / duration) * 9.81f, ForceMode.Acceleration);
            yield return null;
        }

        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        if (!isHeld && rb.velocity.magnitude > 0.1f)
        {
            // Appliquer l'alignement horizontal à chaque frame du vol
            AlignDartHorizontally();
        }
    }

    private void AlignDartHorizontally()
    {
        if (pointHP == null || flightHP == null)
            return;

        // Calculer la direction entre la pointe et l'ailette
        Vector3 forwardDirection = (pointHP.position - flightHP.position).normalized;

        // Bloquer la rotation verticale pour garder la fléchette horizontale
        forwardDirection.y = 0;

        // Appliquer la rotation forcée pour maintenir l'orientation horizontale
        Quaternion targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
        transform.rotation = targetRotation;
    }

    private IEnumerator DestroyAndRespawnDart()
    {
        yield return new WaitForSeconds(5f); // Attendre 5 secondes avant disparition

        // Désactiver l'interaction pour éviter les bugs
        grabInteractable.enabled = false;

        Debug.Log("Avant Réapparition -> Position actuelle : " + transform.position);


        // Réinitialiser la position et la rotation
        transform.position = new Vector3(3.59100008f, 3.227f, -6.01200008f);
        transform.rotation = respawnRotation;

        Debug.Log("Apres Réapparition -> Position actuelle : " + transform.position);


        // Réinitialiser la physique
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(0.5f); // Petite pause pour éviter tout bug visuel

        // Réactiver l'interaction après réapparition
        grabInteractable.enabled = true;
    }
}