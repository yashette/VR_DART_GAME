using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TargetMovementToggleUI : MonoBehaviour
{
    public TargetMover targetMover;
    public TextMeshProUGUI buttonText;

    public void ToggleTargetMovement()
    {
        targetMover.ToggleMovement();
        buttonText.text = targetMover.IsMoving() ? "Static Target" : "Moving Target";
    }
}
