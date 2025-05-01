using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrinkableGlass : MonoBehaviour
{
    public GameObject liquidObject; // Le sous-element qui represente le liquide
    public float drinkingAngleThreshold = 60f; // L'angle pour commencer a boire
    public float drinkingDuration = 2f; // Duree avant de boire en secondes

    private XRGrabInteractable grabInteractable;
    private bool isDrinking = false;
    private float drinkingTimer = 0f;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            Vector3 upDirection = transform.up;
            float angle = Vector3.Angle(upDirection, Vector3.up);

            if (angle > drinkingAngleThreshold)
            {

                AudioManager.Instance.PlayClip(AudioManager.Instance.potionClip);

                if (!isDrinking)
                {
                    // Debut du timer de boisson
                    isDrinking = true;
                    drinkingTimer = 0f;
                }
                else
                {
                    // Continue a boire
                    drinkingTimer += Time.deltaTime;
                    if (drinkingTimer >= drinkingDuration)
                    {
                        if (liquidObject != null && liquidObject.activeSelf)
                        {
                            Debug.Log("Boisson terminee !");
                            liquidObject.SetActive(false); // Cache le liquide apres 2 secondes
                        }
                    }
                }
            }
            else
            {
                // Si le verre est redresse avant la fin, reset
                if (isDrinking)
                {
                    isDrinking = false;
                    drinkingTimer = 0f;
                }
            }
        }
        else
        {
            // Si on lache le verre, reset
            isDrinking = false;
            drinkingTimer = 0f;
        }
    }
}
