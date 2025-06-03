using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer carRenderer;
    public Material[] colorOptions;

    public void ChangeColor(int index)
    {
        if (carRenderer && index < colorOptions.Length)
        {
            var mats = carRenderer.materials;
            mats[0] = colorOptions[index]; // Assume car body is Element 0
            carRenderer.materials = mats;
        }
    }
}
