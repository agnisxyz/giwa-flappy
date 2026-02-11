using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    public AudioClip FlapSound;
    public AudioClip CoinSound;
    public AudioClip DeathSound;

    private void Awake()
    {
        // Singleton pattern: This ensures there is only one AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps audio playing between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }
}