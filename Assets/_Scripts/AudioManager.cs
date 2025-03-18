using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip[] sfx;   //0=brick break/paddle hit, 1=level complete
    [SerializeField] private AudioClip music, bonk;
    [SerializeField] private AudioSource musicSource, sfxSource, bonkSource;
    [SerializeField] private float pitchVarianceMin, pitchVarianceMax;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySoundEffect(int index)
    {
        sfxSource.PlayOneShot(sfx[index]);
    }

    public void PlayBonkEffect()
    {
        bonkSource.pitch = Random.Range(pitchVarianceMin, pitchVarianceMax);
        bonkSource.PlayOneShot(bonk);
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        bonkSource.volume = volume;
    }
    public void EndMusic()
    {
        musicSource.Stop();
    }
}
