using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;                        // Caméra ou tête du joueur
    public float distance = 2f;                   // Distance devant le joueur
    public float fixedHeight = 4.65f;             // Hauteur fixe pour le menu
    public GameObject gameMenu;                   // GameObject parent du menu
    public InputActionProperty showButton;        // Bouton d'affichage

    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            gameMenu.SetActive(!gameMenu.activeSelf);

            if (gameMenu.activeSelf)
            {
                // Direction devant la tête (horizontale uniquement)
                Vector3 forward = new Vector3(head.forward.x, 0, head.forward.z).normalized;

                // Position à une hauteur fixe (y = 4.65)
                Vector3 spawnPosition = head.position + forward * distance;
                spawnPosition.y = fixedHeight;

                gameMenu.transform.position = spawnPosition;

                // Regarder la tête du joueur (en gardant la hauteur fixe)
                Vector3 lookAtTarget = new Vector3(head.position.x, fixedHeight, head.position.z);
                gameMenu.transform.LookAt(lookAtTarget);
                gameMenu.transform.Rotate(0, 180f, 0); // Retourner pour que le menu soit lisible
            }
        }
    }
}
