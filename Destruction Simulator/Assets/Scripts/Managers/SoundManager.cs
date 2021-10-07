using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    [SerializeField] private GameObject soundObject;
    public void PlaySound(AudioClip soundClip, float volume = 0.4f, float variance = 0.2f) {
        GameObject newSound = Instantiate(soundObject);
        AudioSource soundSource = newSound.GetComponent<AudioSource>();

        soundSource.volume = volume;
        soundSource.pitch += Random.Range(-variance, variance);

        soundSource.PlayOneShot(soundClip);

        Destroy(newSound, soundClip.length);
    }

}
