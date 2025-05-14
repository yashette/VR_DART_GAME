using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrinkableGlass : MonoBehaviour
{
    public GameObject liquidObject; // Le sous-élément qui représente le liquide
    public float drinkingAngleThreshold = 60f; // L'angle pour commencer à boire
    public float drinkingDuration = 2f; // Durée avant de boire en secondes

    private XRGrabInteractable grabInteractable;
    private bool isDrinking = false;
    private float drinkingTimer = 0f;
    private bool hasPlayedDrinkingSound = false;

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
                if (!isDrinking)
                {
                    // Début du timer de boisson
                    isDrinking = true;
                    drinkingTimer = 0f;

                    // On joue le son qu'une seule fois au début
                    if (!hasPlayedDrinkingSound)
                    {
                        AudioManager.Instance.PlayClip(AudioManager.Instance.potionClip);
                        hasPlayedDrinkingSound = true;
                    }
                }
                else
                {
                    // Continue à boire
                    drinkingTimer += Time.deltaTime;
                    if (drinkingTimer >= drinkingDuration)
                    {
                        if (liquidObject != null && liquidObject.activeSelf)
                        {
                            liquidObject.SetActive(false); // Cache le liquide après 2 secondes
                        }
                    }
                }
            }
            else
            {
                // Si le verre est redressé avant la fin, reset
                isDrinking = false;
                drinkingTimer = 0f;
                hasPlayedDrinkingSound = false;
            }
        }
        else
        {
            // Si on lâche le verre, reset
            isDrinking = false;
            drinkingTimer = 0f;
            hasPlayedDrinkingSound = false;
        }
    }
}
