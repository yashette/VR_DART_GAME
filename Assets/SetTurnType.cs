using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Ce script permet de choisir entre deux types de rotation dans une exp�rience VR : continue ou par incr�ments (snap)
public class SetTurnType : MonoBehaviour
{

    public ActionBasedSnapTurnProvider snapTurn;                 // R�f�rence au composant de rotation par incr�ments (snap turn)
    public ActionBasedContinuousTurnProvider continuousTurn;     // R�f�rence au composant de rotation continue (smooth turn)

    // M�thode appel�e avec un index (par exemple via un Dropdown UI) pour changer le type de rotation
    public void SetTyoeFromIndex(int index)
    {
        if (index == 0)
        {
            // Si l'index est 0, on active la rotation continue et on d�sactive la rotation par incr�ments
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
        else if(index == 1)
        {
            // Si l'index est 1, on active la rotation par incr�ments et on d�sactive la rotation continue
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }
    }

}
