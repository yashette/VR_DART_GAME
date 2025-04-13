using UnityEngine;
using UnityEngine.InputSystem;

// Ce script anime une main en VR en fonction des entr�es utilisateur (g�chette et prise)
public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;  // Action d'entr�e pour l'animation de la g�chette (pinch/trigger)
    public InputActionProperty gripAnimationAction;   // Action d'entr�e pour l'animation de la prise (grip)
    public Animator handAnimator;                     // R�f�rence � l�Animator de la main

    // Start est appel� au d�but
    void Start()
    {
        
    }

    // Update est appel� � chaque frame
    void Update()
    {
        // Lecture de la valeur de la g�chette (Trigger), comprise entre 0 et 1
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", triggerValue); // Mise � jour du param�tre "Grip" de l'Animator
    }
}
