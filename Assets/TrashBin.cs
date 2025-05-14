using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DrinkableGlass>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
