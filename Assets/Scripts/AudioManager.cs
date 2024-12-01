using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource titleMusic;
    public AudioSource[] bgm;
    public AudioSource[] sfx;
    private int currentTrack;

    private bool isPaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTrack = -1;
    }

    private void Update()
    {
        if (isPaused == false)
        {
            if (bgm[currentTrack].isPlaying == false)
            {
                PlayNextBGM();
            }
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource track in bgm)
        {
            track.Stop();
        }

        titleMusic.Stop();
    }

    public void PlayTitle()
    {
        StopMusic();
        titleMusic.Play();
    }

    public void PlayNextBGM()
    {
        StopMusic();

        currentTrack++;

        if (currentTrack >= bgm.Length)
        {
            currentTrack = 0;
        }
        
        bgm[currentTrack].Play();
    }

    public void PauseMusic()
    {
        isPaused = true;

        bgm[currentTrack].Pause();
    }

    public void ResumeMusic()
    {
        isPaused = false;

        bgm[currentTrack].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void PlaySFXPitchAdjusted(int sfxToPlay)
    {
        sfx[sfxToPlay].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxToPlay);
    }
}
