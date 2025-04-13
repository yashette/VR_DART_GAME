using UnityEngine;
using UnityEngine.InputSystem;

// Ce script anime une main en VR en fonction des entrées utilisateur (gâchette et prise)
public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;  // Action d'entrée pour l'animation de la gâchette (pinch/trigger)
    public InputActionProperty gripAnimationAction;   // Action d'entrée pour l'animation de la prise (grip)
    public Animator handAnimator;                     // Référence à l’Animator de la main

    // Start est appelé au début
    void Start()
    {
        
    }

    // Update est appelé à chaque frame
    void Update()
    {
        // Lecture de la valeur de la gâchette (Trigger), comprise entre 0 et 1
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", triggerValue); // Mise à jour du paramètre "Grip" de l'Animator
    }
}
