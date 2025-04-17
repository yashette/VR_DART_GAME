using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    public XRBaseController controller; // Tu vas y glisser le contrôleur gauche ou droit dans l'inspecteur

    [Range(0, 1)]
    public float amplitude = 0.5f; // Puissance de la vibration
    public float duration = 0.2f; // Durée de la vibration en secondes

    public void TriggerHaptic()
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
}