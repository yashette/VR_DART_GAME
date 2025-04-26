using UnityEngine;
using TMPro;


// Ce script est utilisé pour lier un bouton UI à l'activation/désactivation du mouvement de la cible
public class TargetMovementToggleUI : MonoBehaviour
{
    public TargetMover targetMover;      // Référence au script TargetMover qui contrôle le mouvement de la cible
    public TextMeshProUGUI buttonText;   // Référence au texte du bouton (en UI)
    public HapticFeedback haptic;

    // Méthode appelée lorsqu'on appuie sur le bouton
    public void ToggleTargetMovement()
    {
        // On bascule l’état de mouvement de la cible (active ou non)
        targetMover.ToggleMovement();
        // On met à jour le texte du bouton en fonction de l’état courant
        buttonText.text = targetMover.IsMoving() ? "Static Target" : "Moving Target";
        haptic.TriggerHaptic();
    }
}
