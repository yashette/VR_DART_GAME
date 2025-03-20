using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform pointeFleche; // Référence à POINT_HP

    void Start()
    {
        if (pointeFleche == null)
        {
            // Recherche automatique de POINT_HP si elle n'est pas assignée
            pointeFleche = transform.Find("Point_HP");

            if (pointeFleche == null)
            {
                Debug.LogError("POINT_HP non trouvé ! Vérifie que le nom est correct.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Cible")) // Vérifie que la cible est touchée
        {
            if (pointeFleche != null && collision.contacts[0].thisCollider.gameObject == pointeFleche.gameObject)
            {

                // Désactiver la physique de la flèche
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                // Fixer la flèche à la cible
                transform.SetParent(collision.transform);

            }

        }
    }

}
