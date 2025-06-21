using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] flowers;
    public GameObject cursor;
    public int flowersCount = 0;
    public int flowersGoalCount;
    public string durumText;
    public TextMeshProUGUI goalText;

    public Button button;

    public bool isGoalFinished = false;

    public static Action<int, int, string> OnFloweSpawned;



    private void Start()
    {
        flowersGoalCount = UnityEngine.Random.Range(8,12);
        //UnityEngine.Random.Range(10, 20);
        button.gameObject.SetActive(false);
        OnFloweSpawned?.Invoke(flowersCount, flowersGoalCount, "yere " + flowersGoalCount.ToString() + " adet çiçek ekelim".ToUpper());
        OnFloweSpawned?.Invoke(flowersCount, flowersGoalCount, "yerde " + flowersCount.ToString() + " adet çiçek var");
        goalText.text = "YERE " + flowersGoalCount.ToString() + " ADET ÇÝÇEK EKELÝM".ToUpper();



    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && flowersCount < flowersGoalCount)
        {
            FlowerSpawn();
        }

        if (flowersCount >= flowersGoalCount && !isGoalFinished)
        {
            OnFloweSpawned?.Invoke(flowersCount, flowersGoalCount, "aferin");
            isGoalFinished = true;
            button.gameObject.SetActive(true);

        }
    }

    public void FlowerSpawn()
    {
        GameObject flower = Instantiate(flowers[UnityEngine.Random.Range(0, flowers.Length)], cursor.transform.position, Quaternion.identity);
        flowersCount++;
        OnFloweSpawned?.Invoke(flowersCount, flowersGoalCount, "yerde " + flowersCount.ToString() + " adet çiçek var");
    }

    public void LevelUp()
    {
        SceneManager.LoadScene(2);
    }

    public void Reload()
    {
        SceneManager.LoadScene(1);
    }
}
