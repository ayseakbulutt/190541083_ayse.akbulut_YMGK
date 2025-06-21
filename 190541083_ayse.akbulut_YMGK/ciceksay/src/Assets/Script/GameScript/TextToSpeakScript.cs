using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TextToSpeakScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] wordSound;
    private Queue<AudioClip> soundQueue = new Queue<AudioClip>();
    public Dictionary<string, AudioClip> word_Voice = new Dictionary<string, AudioClip>();
    //public InputField inputField;
    //public Button button;

    private void OnEnable()
    {
        SpawnerScript.OnFloweSpawned += SpawnerScript_OnFlowerSpawned;
        TouchDetection.OnFlowerCollect += SpawnerScript_OnFlowerSpawned;
        TouchDetectionM3.OnFlowerCollect += SpawnerScript_OnFlowerSpawned;
        TouchDetectionM4.OnFlowerCollect += SpawnerScript_OnFlowerSpawned;
        TouchDetectionM5.OnFlowerCollect += SpawnerScript_OnFlowerSpawned;
        TouchDetectionM6.OnFlowerCollect += SpawnerScript_OnFlowerSpawned;

    }



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Butonu t�klamay� dinle
        //Button button = GetComponent<Button>();
        //button.onClick.AddListener(Oku);

    }

    // Butona t�klan�nca �a�r�lacak fonksiyon


    private void Update()
    {
        // Kuyrukta ses var m� ve audio kayna�� �al�yor mu kontrol et
        if (soundQueue != null && soundQueue.Count != 0 && !audioSource.isPlaying)
        {
            audioSource.clip = soundQueue.Dequeue();
            audioSource.Play();
            //Debug.Log(audioSource.clip.name);
            //if (soundQueue.Count == 0)
            //{
            //    Debug.Log("Okuma tamamland�.");
            //}
        }
    }
    private void SpawnerScript_OnFlowerSpawned(int flowersCount, int flowersGoalCount, string t)
    {
        //TextToSpeak(flowersCount.ToString());

        Oku(t);
    }



    public void Oku(string metin)
    {
        //string metin = inputField.text;
        TextToSpeak(metin);
    }
    public void TextToSpeak(string phrase)
    {
        if (word_Voice.Count == 0)
        {
            foreach (var word in wordSound)
            {
                word_Voice.Add(word.name, word);
            }
        }
        // Kelimeleri ve sesleri e�le�tir

        phrase = phrase.ToLower();
        // Metni kelimelere ay�r
        string[] words = phrase.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {

        }
        // Her kelime i�in sesi kuyru�a ekle
        foreach (var word in words)
        {
            if (word_Voice.ContainsKey(word))
            {
                Debug.Log(word);
                soundQueue.Enqueue(word_Voice[word]);
            }
        }
    }
}
