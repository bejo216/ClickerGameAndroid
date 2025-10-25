using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //SoundManager.Instance.PlayChop(); -- for starting sounds
    public static SoundManager Instance;   // Singleton reference

    public AudioSource audioSource;        // The AudioSource component

    public AudioClip chopSound;
    public AudioClip clickSound;
    public AudioClip buySound;
    public AudioClip declineSound;
    public AudioClip treeFallSound;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Play a sound once
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Example helper function
    public void PlayChop()
    {
        PlaySound(chopSound);
    }
    //UI SOUNDS
    public void PlayClickSound()
    {
        PlaySound(clickSound);
    }

    public void PlayBuySound()
    {
        PlaySound(buySound);
    }

    public void PlayDeclineSound()
    {
        PlaySound(declineSound);
    }

    public void PlayTreeFallSound()
    {
        PlaySound(treeFallSound);
    }
}
