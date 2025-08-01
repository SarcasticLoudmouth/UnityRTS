using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance ??= this;
        }
    }
    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Spawn gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign Audio Clip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play clip
        audioSource.Play();

        //get length of clip
        float clipLength = audioSource.clip.length;

        // Destroy the audio source after the clip has finished playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public void StopSoundFX()
    {
        if (soundFXObject.isPlaying)
        {
            soundFXObject.Stop();
        }
    }
}



