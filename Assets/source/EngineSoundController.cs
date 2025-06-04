using UnityEngine;

public class EngineSoundController : MonoBehaviour
{
    public AudioSource engineAudio;

    public void PlayEngineSound()
    {
        if (engineAudio != null && !engineAudio.isPlaying)
        {
            engineAudio.Play();
        }
    }

    public void StopEngineSound()
    {
        if (engineAudio != null && engineAudio.isPlaying)
        {
            engineAudio.Stop();
        }
    }
}
