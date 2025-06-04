using UnityEngine;

public class EngineAudioManager : MonoBehaviour
{
    public AudioSource engineSource;

    public void PlayEngineSound()
    {
        if (engineSource != null && engineSource.enabled && engineSource.gameObject.activeInHierarchy)
        {
            engineSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource is disabled or inactive.");
        }
    }
}
