using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform pointeFleche; // R�f�rence � POINT_HP

    void Start()
    {
        if (pointeFleche == null)
        {
            // Recherche automatique de POINT_HP si elle n'est pas assign�e
            pointeFleche = transform.Find("Point_HP");

            if (pointeFleche == null)
            {
                Debug.LogError("POINT_HP non trouv� ! V�rifie que le nom est correct.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Cible")) // V�rifie que la cible est touch�e
        {
            if (pointeFleche != null && collision.contacts[0].thisCollider.gameObject == pointeFleche.gameObject)
            {

                // D�sactiver la physique de la fl�che
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

                // Fixer la fl�che � la cible
                transform.SetParent(collision.transform);

            }

        }
    }

}
