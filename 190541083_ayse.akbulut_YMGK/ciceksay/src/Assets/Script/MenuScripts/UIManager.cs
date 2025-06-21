using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI countText;






    private void OnEnable()
    {

        SpawnerScript.OnFloweSpawned += SpawnerScript_OnFlowerSpawned;
        TouchDetection.OnFlowerCollect += TouchDetection_OnFlowerCollect;
        TouchDetectionM3.OnFlowerCollect += TouchDetection_OnFlowerCollect;
        TouchDetectionM4.OnFlowerCollect += TouchDetection_OnFlowerCollect;
        TouchDetectionM5.OnFlowerCollect += TouchDetection_OnFlowerCollect;
        TouchDetectionM6.OnFlowerCollect += TouchDetection_OnFlowerCollect;

    }



    private void TouchDetection_OnFlowerCollect(int arg1, int arg2, string arg3)
    {
        countText.text = arg3.ToUpper();
    }

    private void SpawnerScript_OnFlowerSpawned(int flowersCount, int flowersGoalCount, string text)
    {

        countText.text = text.ToUpper();

    }

    private void OnDisable()
    {
        SpawnerScript.OnFloweSpawned -= SpawnerScript_OnFlowerSpawned;
    }
}
