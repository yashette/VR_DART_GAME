using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Ce script permet de choisir entre deux types de rotation dans une expérience VR : continue ou par incréments (snap)
public class SetTurnType : MonoBehaviour
{

    public ActionBasedSnapTurnProvider snapTurn;                 // Référence au composant de rotation par incréments (snap turn)
    public ActionBasedContinuousTurnProvider continuousTurn;     // Référence au composant de rotation continue (smooth turn)

    // Méthode appelée avec un index (par exemple via un Dropdown UI) pour changer le type de rotation
    public void SetTyoeFromIndex(int index)
    {
        if (index == 0)
        {
            // Si l'index est 0, on active la rotation continue et on désactive la rotation par incréments
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
        else if(index == 1)
        {
            // Si l'index est 1, on active la rotation par incréments et on désactive la rotation continue
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }
    }

}
