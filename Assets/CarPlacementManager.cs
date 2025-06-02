using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CarPlacementManager : MonoBehaviour
{
    public GameObject carPrefab;             // Car prefab to place
    private GameObject spawnedCar;           // To keep track of the placed car
    private ARRaycastManager raycastManager;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedCar == null)
                {
                    spawnedCar = Instantiate(carPrefab, hitPose.position, Quaternion.LookRotation(Vector3.forward));

                }
                else
                {
                    spawnedCar.transform.position = hitPose.position;
                }
            }
        }
    }
}
