using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AreaMeasurement : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    private float totalArea = 0f;
    public float maxArea = 10f; // Maksimum alan s�n�r�
    private bool isMeasuring = true; // Tarama durumu

    public GameObject cursor;
    public GameObject flowerArea;

    void Start()
    {
        // ARRaycastManager �rne�ini al
        //raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!isMeasuring)
            this.gameObject.SetActive(false);

        else
        {
            // Ekran�n merkezinden ray olu�tur
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                // En yak�n d�zlemi bul
                ARPlane plane = hits[0].trackable as ARPlane;

                if (plane != null)
                {
                    // D�zlem alan�n� hesapla
                    totalArea = plane.size.x * plane.size.y;

                    // Maksimum alan s�n�r�n� kontrol et
                    if (totalArea > maxArea)
                    {
                        Debug.Log("Maksimum alan s�n�r� a��ld�. Tarama durduruluyor.");
                        Instantiate(flowerArea,cursor.transform.position,cursor.transform.rotation);
                        isMeasuring = false;

                    }

                    Debug.Log("Toplam Alan: " + totalArea.ToString() + " metrekare");
                }
            }
        }

       
    }
}
