using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Cette classe hérite de XRGrabInteractable pour personnaliser le comportement de la saisie d'un objet XR avec un offset
public class XROffsetGrabInteractable : XRGrabInteractable
{
    // Position et rotation locales initiales du point d'attache
    private Vector3 initialLocalPos;
    private Quaternion initialLocalRot;


    // Méthode appelée au début (au lancement de la scène)
    void Start()
    {
        // Si aucun point d'attache n'est défini, on en crée un nouveau par défaut
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grav Pivot");
            attachPoint.transform.SetParent(transform, false);// On le place comme enfant de l'objet actuel
            attachTransform = attachPoint.transform;// On le définit comme point d'attache
        }
        else
        {
            // Si un point d'attache existe déjà, on enregistre sa position et sa rotation locales
            initialLocalPos = attachTransform.localPosition;
            initialLocalRot = attachTransform.localRotation;
        }
    }

    // Méthode appelée à chaque frame (non utilisée ici)
    void Update()
    {
        
    }

    // Méthode appelée quand un interactor sélectionne (saisit) cet objet
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Si l'interactor est un XRDirectInteractor (main directe du joueur)
        if (args.interactorObject is XRDirectInteractor)
        {
            // On aligne le point d'attache à la position et à la rotation de la main
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            // Sinon (ex: rayon laser), on remet le point d'attache à sa position/rotation initiale locale
            attachTransform.localPosition = initialLocalPos;
            attachTransform.rotation = initialLocalRot;
        }

        // On appelle la méthode de base pour conserver le comportement standard
        base.OnSelectEntered(args);
        
    }
}
