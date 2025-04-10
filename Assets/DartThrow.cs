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
    public float throwForceMultiplier = 5f;
    public float rotationSmoothness = 15f;

    public Quaternion respawnRotation = Quaternion.Euler(0, 0, 0); // Rotation après réapparition

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        rb.isKinematic = true;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void Update()
    {
        if (isHeld)
        {
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
        rb.isKinematic = false;
        rb.useGravity = true;

        StartCoroutine(ApplyThrowVelocity());
        StartCoroutine(DestroyAndRespawnDart());
    }

    private IEnumerator ApplyThrowVelocity()
    {
        yield return null;

        Vector3 throwDirection = velocity.normalized;

        rb.velocity = throwDirection * throwForceMultiplier;
        rb.angularVelocity = Vector3.zero;

        Debug.Log("DartThrow: Vitesse appliquée -> " + rb.velocity);
    }

    void FixedUpdate()
    {
        if (!isHeld && rb.velocity.magnitude > 0.1f)
        {
            AlignDartWithVelocity();
        }
    }

    private void AlignDartWithVelocity()
    {
        if (rb.velocity.sqrMagnitude > 0.01f)
        {
            Vector3 direction = rb.velocity.normalized;

            // Rotation de base vers la direction de la trajectoire
            Quaternion baseRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Correction car le modèle est orienté vers le haut (Y+) au lieu de l’avant (Z+)
            Quaternion correctiveRotation = Quaternion.Euler(-90f, 0f, 0f); // ajuste ici si besoin
            Quaternion targetRotation = baseRotation * correctiveRotation;

            // Appliquer en douceur
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * rotationSmoothness));
        }
    }

    private IEnumerator DestroyAndRespawnDart()
    {
        yield return new WaitForSeconds(5f);

        grabInteractable.enabled = false;

        transform.position = new Vector3(1.676f, 3.67199993f, -0.170000002f);
        transform.rotation = respawnRotation;

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        grabInteractable.enabled = true;
    }
}
