using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; // Müziği çalacak kaynak
    [SerializeField] private AudioSource sfxSource;   // Efektleri çalacak kaynak

    [Header("Music Clips")]
    public AudioClip backgroundMusic;

    [Header("SFX Clips")]
    public AudioClip FlapSound;
    public AudioClip CoinSound;
    public AudioClip DeathSound;
    public AudioClip CountdownBeep; // Birazdan ekleyeceğin geri sayım sesi
    public AudioClip GoSound;        // Birazdan ekleyeceğin GO sesi

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahneler arası müzik kesilmesin diye
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Oyun açıldığında müziği başlat
        PlayMusic(backgroundMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true; // Müziğin sürekli dönmesini sağlar
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}