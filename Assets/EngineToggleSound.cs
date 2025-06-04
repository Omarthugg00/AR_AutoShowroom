using UnityEngine;

public class EngineToggleSound : MonoBehaviour
{
    public AudioSource engineAudio;
    private bool isPlaying = false;

    public void ToggleEngineSound()
    {
        if (engineAudio == null)
        {
            Debug.LogError("AudioSource not assigned.");
            return;
        }

        if (isPlaying)
        {
            engineAudio.Stop();
        }
        else
        {
            engineAudio.Play();
        }

        isPlaying = !isPlaying;
    }
}
