using UnityEngine;

public class CarCustomizer : MonoBehaviour
{
    public GameObject carBody;              // MeshRenderer target (usually the body)
    public Material[] bodyMaterials;        // Materials to switch between
    private int colorIndex = 0;

    public void ChangeBodyColor()
    {
        if (carBody != null && bodyMaterials.Length > 0)
        {
            colorIndex = (colorIndex + 1) % bodyMaterials.Length;
            carBody.GetComponent<Renderer>().material = bodyMaterials[colorIndex];
        }

    }
    public AudioSource engineAudio;
    private bool isEngineOn = false;

    public void ToggleEngine()
    {
        if (engineAudio == null) return;

        if (isEngineOn)
        {
            engineAudio.Stop();
        }
        else
        {
            engineAudio.Play();
        }

        isEngineOn = !isEngineOn;
    }

}
