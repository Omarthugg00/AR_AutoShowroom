using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class ARStartupFix : MonoBehaviour
{
    public ARSession arSession;

    IEnumerator Start()
    {
        arSession.enabled = false;
        yield return new WaitForSeconds(1.0f);
        arSession.enabled = true;
    }
}
