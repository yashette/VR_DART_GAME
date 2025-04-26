using UnityEngine;
using TMPro;


// Ce script est utilis� pour lier un bouton UI � l'activation/d�sactivation du mouvement de la cible
public class TargetMovementToggleUI : MonoBehaviour
{
    public TargetMover targetMover;      // R�f�rence au script TargetMover qui contr�le le mouvement de la cible
    public TextMeshProUGUI buttonText;   // R�f�rence au texte du bouton (en UI)
    public HapticFeedback haptic;

    // M�thode appel�e lorsqu'on appuie sur le bouton
    public void ToggleTargetMovement()
    {
        // On bascule l��tat de mouvement de la cible (active ou non)
        targetMover.ToggleMovement();
        // On met � jour le texte du bouton en fonction de l��tat courant
        buttonText.text = targetMover.IsMoving() ? "Static Target" : "Moving Target";
        haptic.TriggerHaptic();
    }
}
