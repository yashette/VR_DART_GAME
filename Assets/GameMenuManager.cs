using UnityEngine;
using UnityEngine.InputSystem;

// Ce script permet d�afficher ou de masquer un menu en VR devant le joueur lorsqu�il appuie sur un bouton.
public class GameMenuManager : MonoBehaviour
{
    public Transform head;                        // R�f�rence � la t�te ou cam�ra du joueur
    public float distance = 2f;                   // Distance � laquelle le menu appara�t devant le joueur
    public float fixedHeight = 4.65f;             // Hauteur fixe du menu, peu importe la hauteur de la t�te
    public GameObject gameMenu;                   // GameObject contenant le menu � afficher/masquer
    public InputActionProperty showButton;        // Bouton (Input System) utilis� pour afficher/masquer le menu

    void Update()
    {
        // V�rifie si le bouton a �t� press� pendant cette frame
        if (showButton.action.WasPressedThisFrame())
        {
            // Bascule l��tat actif du menu (affiche si cach�, cache si affich�)
            gameMenu.SetActive(!gameMenu.activeSelf);

            // Si le menu vient d��tre activ�, on le positionne devant le joueur
            if (gameMenu.activeSelf)
            {
                // Calcul de la direction horizontale devant la t�te (on ignore l�axe Y)
                Vector3 forward = new Vector3(head.forward.x, 0, head.forward.z).normalized;

                // Position de spawn = devant le joueur + � une hauteur fixe
                Vector3 spawnPosition = head.position + forward * distance;
                spawnPosition.y = fixedHeight;

                // Le menu regarde la t�te du joueur (en gardant la hauteur fixe)
                gameMenu.transform.position = spawnPosition;

                // Regarder la t�te du joueur (en gardant la hauteur fixe)
                Vector3 lookAtTarget = new Vector3(head.position.x, fixedHeight, head.position.z);
                gameMenu.transform.LookAt(lookAtTarget);

                // On le fait pivoter de 180� pour que le texte soit dans le bon sens
                gameMenu.transform.Rotate(0, 180f, 0);
            }
        }
    }
}
