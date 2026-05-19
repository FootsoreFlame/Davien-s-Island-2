using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip normalMusic;
    public AudioClip chaseMusic;

    private AudioClip currentClip;

    void Start()
    {
        PlayNormal();
    }

    public void PlayNormal()
    {
        if (currentClip == normalMusic) return;

        currentClip = normalMusic;
        audioSource.clip = normalMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayChase()
    {
        if (currentClip == chaseMusic) return;

        currentClip = chaseMusic;
        audioSource.clip = chaseMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}