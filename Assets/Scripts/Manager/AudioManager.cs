using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource BgSource;
    public AudioSource SfxSource;

    [Header("Audio Controller")]
    public AudioController controller;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBg(AudioType type)
    {
        if (controller == null) return;

        AudioClip clip = controller.GetAudio(type);
        if (clip == null || BgSource == null) return;

        if (BgSource.isPlaying)
            BgSource.Stop();

        BgSource.clip = clip;
        BgSource.Play();
    }

    public void PlaySfx(AudioType type)
    {
        if (controller == null) return;

        AudioClip clip = controller.GetAudio(type);
        if (clip == null || SfxSource == null) return;

        if (SfxSource.isPlaying)
            SfxSource.Stop();

        SfxSource.clip = clip;
        SfxSource.Play();
    }

    public void StopBg()
    {
        if (BgSource != null && BgSource.isPlaying)
            BgSource.Stop();
    }

    public void StopSfx()
    {
        if (SfxSource != null && SfxSource.isPlaying)
            SfxSource.Stop();
    }
}
