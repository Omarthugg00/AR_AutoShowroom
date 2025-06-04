using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class MarkerSpawner : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public List<NamedPrefab> prefabLibrary;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
            SpawnPrefab(trackedImage);

        foreach (var trackedImage in args.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject obj))
                {
                    obj.SetActive(true);
                    obj.transform.position = trackedImage.transform.position;
                    obj.transform.rotation = trackedImage.transform.rotation;
                }
            }
            else
            {
                if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out GameObject obj))
                    obj.SetActive(false);
            }
        }
    }

    void SpawnPrefab(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (!spawnedPrefabs.ContainsKey(imageName))
        {
            foreach (var item in prefabLibrary)
            {
                if (item.imageName == imageName)
                {
                    GameObject newPrefab = Instantiate(item.prefab, trackedImage.transform.position, trackedImage.transform.rotation);
                    newPrefab.transform.parent = trackedImage.transform;
                    spawnedPrefabs[imageName] = newPrefab;
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class NamedPrefab
{
    public string imageName;
    public GameObject prefab;
}
