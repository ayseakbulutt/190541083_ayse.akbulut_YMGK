using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CursorScript : MonoBehaviour
{
    private ARRaycastManager rayManager;
    [SerializeField] private GameObject visual;

    public GameObject cursor;


    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();

        visual = cursor.transform.GetChild(0).gameObject;

        visual.SetActive(false);

    }

    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            cursor.transform.position = hits[0].pose.position;
            cursor.transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }

    }


}
