using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BarmanInteraction : MonoBehaviour
{
    public GameObject beerPrefab;
    private XRBaseInteractable interactable;
    public HapticFeedback haptic;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        if (beerPrefab != null)
        {
            haptic.TriggerHaptic();
            Vector3 spawnPoint = new Vector3(8.34602165f, 3.02082014f, -15.1160002f);
            GameObject newBeer = Instantiate(beerPrefab, spawnPoint, Quaternion.identity);
            Rigidbody rb = newBeer.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = false; // Pour qu'il tombe naturellement sur le bar si besoin
        }
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelected);
    }
}
