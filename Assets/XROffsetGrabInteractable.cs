using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Cette classe h�rite de XRGrabInteractable pour personnaliser le comportement de la saisie d'un objet XR avec un offset
public class XROffsetGrabInteractable : XRGrabInteractable
{
    // Position et rotation locales initiales du point d'attache
    private Vector3 initialLocalPos;
    private Quaternion initialLocalRot;


    // M�thode appel�e au d�but (au lancement de la sc�ne)
    void Start()
    {
        // Si aucun point d'attache n'est d�fini, on en cr�e un nouveau par d�faut
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grav Pivot");
            attachPoint.transform.SetParent(transform, false);// On le place comme enfant de l'objet actuel
            attachTransform = attachPoint.transform;// On le d�finit comme point d'attache
        }
        else
        {
            // Si un point d'attache existe d�j�, on enregistre sa position et sa rotation locales
            initialLocalPos = attachTransform.localPosition;
            initialLocalRot = attachTransform.localRotation;
        }
    }

    // M�thode appel�e � chaque frame (non utilis�e ici)
    void Update()
    {
        
    }

    // M�thode appel�e quand un interactor s�lectionne (saisit) cet objet
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Si l'interactor est un XRDirectInteractor (main directe du joueur)
        if (args.interactorObject is XRDirectInteractor)
        {
            // On aligne le point d'attache � la position et � la rotation de la main
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            // Sinon (ex: rayon laser), on remet le point d'attache � sa position/rotation initiale locale
            attachTransform.localPosition = initialLocalPos;
            attachTransform.rotation = initialLocalRot;
        }

        // On appelle la m�thode de base pour conserver le comportement standard
        base.OnSelectEntered(args);
        
    }
}
