using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;

    [Header("-----AudioSource-----")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("-----AudioClip-----")]
    [SerializeField] private AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip collect;
    public AudioClip finish;

    public static AudioController Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // thêm sự kiện khi loadScene
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Debug.LogWarning("There should only be 1 class AudioController");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.volume = 1.0f;
        sfxSource.volume = 1.0f;
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }
    public void SetSfxVolume(float value)
    {
        sfxSource.volume = value;
    }
    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
    public float GetSfxVolume()
    {
        return sfxSource.volume;
    }

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    Debug.Log("Scene loaded: " + scene.name);
    //    PlayMusic();
    //}

    //private void OnDestroy()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
}
