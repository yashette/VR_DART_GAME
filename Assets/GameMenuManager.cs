using UnityEngine;
using UnityEngine.InputSystem;

// Ce script permet d’afficher ou de masquer un menu en VR devant le joueur lorsqu’il appuie sur un bouton.
public class GameMenuManager : MonoBehaviour
{
    public Transform head;                        // Référence à la tête ou caméra du joueur
    public float distance = 2f;                   // Distance à laquelle le menu apparaît devant le joueur
    public float fixedHeight = 4.65f;             // Hauteur fixe du menu, peu importe la hauteur de la tête
    public GameObject gameMenu;                   // GameObject contenant le menu à afficher/masquer
    public InputActionProperty showButton;        // Bouton (Input System) utilisé pour afficher/masquer le menu

    void Update()
    {
        // Vérifie si le bouton a été pressé pendant cette frame
        if (showButton.action.WasPressedThisFrame())
        {
            // Bascule l’état actif du menu (affiche si caché, cache si affiché)
            gameMenu.SetActive(!gameMenu.activeSelf);

            // Si le menu vient d’être activé, on le positionne devant le joueur
            if (gameMenu.activeSelf)
            {
                // Calcul de la direction horizontale devant la tête (on ignore l’axe Y)
                Vector3 forward = new Vector3(head.forward.x, 0, head.forward.z).normalized;

                // Position de spawn = devant le joueur + à une hauteur fixe
                Vector3 spawnPosition = head.position + forward * distance;
                spawnPosition.y = fixedHeight;

                // Le menu regarde la tête du joueur (en gardant la hauteur fixe)
                gameMenu.transform.position = spawnPosition;

                // Regarder la tête du joueur (en gardant la hauteur fixe)
                Vector3 lookAtTarget = new Vector3(head.position.x, fixedHeight, head.position.z);
                gameMenu.transform.LookAt(lookAtTarget);

                // On le fait pivoter de 180° pour que le texte soit dans le bon sens
                gameMenu.transform.Rotate(0, 180f, 0);
            }
        }
    }
}
