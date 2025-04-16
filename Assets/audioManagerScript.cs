using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    [Header("Annonces")]
    public AudioClip bustClip;
    public AudioClip nextPlayerClip;
    public AudioClip victoryP1Clip;
    public AudioClip victoryP2Clip;
    public AudioClip doubleClip;
    public AudioClip tripleJ2Clip;
    public AudioClip bonzayClip;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}

