using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlecheScript : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int pointsParFleche = 50;

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

                int score = GetScore(collision); // Appel de la méthode GetScore

                // Mise à jour du score
                if (scoreManager != null)
                {
                    scoreManager.SoustrairePoints(score);
                }

            }

        }
    }


    public int GetScore(Collision collision)
    {
        int score = 0;

        if (collision.collider.gameObject.name == "Cylinder.005" ) {
            score = 18;
        }
        else if (collision.collider.gameObject.name == "Cylinder.006")
        {
            score = 36;
        }
        else if (collision.collider.gameObject.name == "Cylinder.007")
        {
            score = 18;
        }
        else if (collision.collider.gameObject.name == "Cylinder.008")
        {
            score = 54;
        }
        else if (collision.collider.gameObject.name == "Cylinder.001")
        {
            score = 50;
        }
        else if (collision.collider.gameObject.name == "Cylinder.003")
        {
            score = 25;
        }
        else if (collision.collider.gameObject.name == "Cylinder.009")
        {
            score = 4;
        }
        else if (collision.collider.gameObject.name == "Cylinder.010")
        {
            score = 8;
        }
        else if (collision.collider.gameObject.name == "Cylinder.011")
        {
            score = 4;
        }
        else if (collision.collider.gameObject.name == "Cylinder.012")
        {
            score = 12;
        }
        else if (collision.collider.gameObject.name == "Cylinder.013")
        {
            score = 13;
        }
        else if (collision.collider.gameObject.name == "Cylinder.014")
        {
            score = 26;

        }
        else if (collision.collider.gameObject.name == "Cylinder.015")
        {
            score = 13;
        }
        else if (collision.collider.gameObject.name == "Cylinder.016")
        {
            score = 39;
        }
        else if (collision.collider.gameObject.name == "Cylinder.017")
        {
            score = 6;
        }
        else if (collision.collider.gameObject.name == "Cylinder.018")
        {
            score = 12;
        }
        else if (collision.collider.gameObject.name == "Cylinder.019")
        {
            score = 6;
        }
        else if (collision.collider.gameObject.name == "Cylinder.020")
        {
            score = 18;
        }
        else if (collision.collider.gameObject.name == "Cylinder.021")
        {
            score = 10;
        }
        else if (collision.collider.gameObject.name == "Cylinder.022")
        {
            score = 20;
        }
        else if (collision.collider.gameObject.name == "Cylinder.023")
        {
            score = 10;
        }
        else if (collision.collider.gameObject.name == "Cylinder.024")
        {
            score = 30;
        }
        else if (collision.collider.gameObject.name == "Cylinder.025")
        {
            score = 15;
        }
        else if (collision.collider.gameObject.name == "Cylinder.026")
        {
            score = 30;
        }
        else if (collision.collider.gameObject.name == "Cylinder.027")
        {
            score = 15;
        }
        else if (collision.collider.gameObject.name == "Cylinder.028")
        {
            score = 45;
        }
        else if (collision.collider.gameObject.name == "Cylinder.029")
        {
            score = 2;
        }
        else if (collision.collider.gameObject.name == "Cylinder.030")
        {
            score = 4;
        }
        else if (collision.collider.gameObject.name == "Cylinder.031")
        {
            score = 2;
        }
        else if (collision.collider.gameObject.name == "Cylinder.032")
        {
            score = 6;
        }
        else if (collision.collider.gameObject.name == "Cylinder.033")
        {
            score = 17;
        }
        else if (collision.collider.gameObject.name == "Cylinder.034")
        {
            score = 34;
        }
        else if (collision.collider.gameObject.name == "Cylinder.035")
        {
            score = 17;
        }
        else if (collision.collider.gameObject.name == "Cylinder.036")
        {
            score = 51;
        }
        else if (collision.collider.gameObject.name == "Cylinder.037")
        {
            score = 3;
        }
        else if (collision.collider.gameObject.name == "Cylinder.038")
        {
            score = 6;
        }
        else if (collision.collider.gameObject.name == "Cylinder.039")
        {
            score = 3;
        }
        else if (collision.collider.gameObject.name == "Cylinder.040")
        {
            score = 9;
        }
        else if (collision.collider.gameObject.name == "Cylinder.041")
        {
            score = 19;
        }
        else if (collision.collider.gameObject.name == "Cylinder.042")
        {
            score = 38;
        }
        else if (collision.collider.gameObject.name == "Cylinder.043")
        {
            score = 19;
        }
        else if (collision.collider.gameObject.name == "Cylinder.044")
        {
            score = 57;
        }
        else if (collision.collider.gameObject.name == "Cylinder.045")
        {
            score = 7;
        }
        else if (collision.collider.gameObject.name == "Cylinder.046")
        {
            score = 14;
        }
        else if (collision.collider.gameObject.name == "Cylinder.047")
        {
            score = 7;
        }
        else if (collision.collider.gameObject.name == "Cylinder.048")
        {
            score = 21;
        }
        else if (collision.collider.gameObject.name == "Cylinder.049")
        {
            score = 16;
        }
        else if (collision.collider.gameObject.name == "Cylinder.050")
        {
            score = 32;
        }
        else if (collision.collider.gameObject.name == "Cylinder.051")
        {
            score = 16;
        }
        else if (collision.collider.gameObject.name == "Cylinder.052")
        {
            score = 48;
        }
        else if (collision.collider.gameObject.name == "Cylinder.053")
        {
            score = 8;
        }
        else if (collision.collider.gameObject.name == "Cylinder.054")
        {
            score = 16;
        }
        else if (collision.collider.gameObject.name == "Cylinder.055")
        {
            score = 8;
        }
        else if (collision.collider.gameObject.name == "Cylinder.056")
        {
            score = 24;
        }
        else if (collision.collider.gameObject.name == "Cylinder.057")
        {
            score = 11;
        }
        else if (collision.collider.gameObject.name == "Cylinder.058")
        {
            score = 22;
        }
        else if (collision.collider.gameObject.name == "Cylinder.059")
        {
            score = 11;
        }
        else if (collision.collider.gameObject.name == "Cylinder.060")
        {
            score = 33;
        }
        else if (collision.collider.gameObject.name == "Cylinder.061")
        {
            score = 14;
        }
        else if (collision.collider.gameObject.name == "Cylinder.062")
        {
            score = 28;
        }
        else if (collision.collider.gameObject.name == "Cylinder.063")
        {
            score = 14;
        }
        else if (collision.collider.gameObject.name == "Cylinder.064")
        {
            score = 42;
        }
        else if (collision.collider.gameObject.name == "Cylinder.065")
        {
            score = 9;
        }
        else if (collision.collider.gameObject.name == "Cylinder.066")
        {
            score = 18;
        }
        else if (collision.collider.gameObject.name == "Cylinder.067")
        {
            score = 9;
        }
        else if (collision.collider.gameObject.name == "Cylinder.068")
        {
            score = 27;
        }
        else if (collision.collider.gameObject.name == "Cylinder.069")
        {
            score = 12;
        }
        else if (collision.collider.gameObject.name == "Cylinder.070")
        {
            score = 24;
        }
        else if (collision.collider.gameObject.name == "Cylinder.071")
        {
            score = 12;
        }
        else if (collision.collider.gameObject.name == "Cylinder.072")
        {
            score = 36;
        }
        else if (collision.collider.gameObject.name == "Cylinder.073")
        {
            score = 5;
        }
        else if (collision.collider.gameObject.name == "Cylinder.074")
        {
            score = 10;
        }
        else if (collision.collider.gameObject.name == "Cylinder.075")
        {
            score = 5;
        }
        else if (collision.collider.gameObject.name == "Cylinder.076")
        {
            score = 15;
        }
        else if (collision.collider.gameObject.name == "Cylinder.077")
        {
            score = 20;
        }
        else if (collision.collider.gameObject.name == "Cylinder.078")
        {
            score = 40;
        }
        else if (collision.collider.gameObject.name == "Cylinder.079")
        {
            score = 20;
        }
        else if (collision.collider.gameObject.name == "Cylinder.080")
        {
            score = 60;
        }
        else if (collision.collider.gameObject.name == "Cylinder.081")
        {
            score = 1;
        }
        else if (collision.collider.gameObject.name == "Cylinder.082")
        {
            score = 2;
        }
        else if (collision.collider.gameObject.name == "Cylinder.083")
        {
            score = 1;
        }
        else if (collision.collider.gameObject.name == "Cylinder.084")
        {
            score = 3;
        }
        


        return score;
    }

}
