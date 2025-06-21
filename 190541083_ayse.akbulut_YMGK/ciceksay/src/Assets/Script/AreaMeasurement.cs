using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AreaMeasurement : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    private float totalArea = 0f;
    public float maxArea = 10f; // Maksimum alan sýnýrý
    private bool isMeasuring = true; // Tarama durumu

    public GameObject cursor;
    public GameObject flowerArea;

    void Start()
    {
        // ARRaycastManager örneðini al
        //raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!isMeasuring)
            this.gameObject.SetActive(false);

        else
        {
            // Ekranýn merkezinden ray oluþtur
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                // En yakýn düzlemi bul
                ARPlane plane = hits[0].trackable as ARPlane;

                if (plane != null)
                {
                    // Düzlem alanýný hesapla
                    totalArea = plane.size.x * plane.size.y;

                    // Maksimum alan sýnýrýný kontrol et
                    if (totalArea > maxArea)
                    {
                        Debug.Log("Maksimum alan sýnýrý aþýldý. Tarama durduruluyor.");
                        Instantiate(flowerArea,cursor.transform.position,cursor.transform.rotation);
                        isMeasuring = false;

                    }

                    Debug.Log("Toplam Alan: " + totalArea.ToString() + " metrekare");
                }
            }
        }

       
    }
}
