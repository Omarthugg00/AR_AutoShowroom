using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class CarPlacementManager : MonoBehaviour
{
    public GameObject carPrefab;
    private GameObject spawnedCar;
    private ARRaycastManager raycastManager;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (CarSpawnState.carHasSpawned) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                spawnedCar = Instantiate(carPrefab, hitPose.position, Quaternion.LookRotation(Vector3.forward));
                CarSpawnState.carHasSpawned = true;

                Debug.Log("Car placed by touch.");
            }
        }
    }
}
