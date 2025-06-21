# 🌸 Çiç.ek Toplayalım – Game Design Document (GDD)

## 🎮 Oyun Adı
**Çiç.ek Toplayalım**

## 📦 Geliştirme Bilgileri
- **Geliştirici:** Ayse Akbulut 
- **Motor:** Unity (URP + AR Foundation)  
- **Platform:** Android (AR destekli cihazlar)  
- **Sanat Tarzı:** Low Poly  
- **Hedef Kitle:** 4-8 yaş arası çocuklar  
- **Oynanış Süresi:** Her bölüm 3-5 dakika  
- **Tema:** Eğitsel – Sayma, düzine ve deste öğretimi

## 🧠 Oyun Tanımı
“Çiç.ek Toplayalım”, artırılmış gerçeklik (AR) teknolojisini kullanarak çocuklara sayıları eğlenceli ve etkileşimli bir şekilde öğreten bir mobil oyundur. Oyuncular, gerçek dünyada yere yerleştirilen çiçekleri toplayarak sayma becerilerini geliştirir. Düzine ve deste gibi kavramlar oyuna eğlenceli mekaniklerle entegre edilmiştir.

## 🕹️ Temel Mekanikler
- **AR Kamera Kullanımı:** Yere çiçek yerleştirilir.
- **Toplama Mekaniği:** Ekrana dokunarak çiçek toplanır.
- **Sesli Geri Bildirim:** Toplanan her çiçekte sesli sayma ("Bir... iki... üç...").
- **Yanlış Sayı Uyarısı:** Sevimli uyarı sesi.
- **Bölüm Sonu Değerlendirme:** Başarıya göre yıldızlı ya da sesli ödül.

## 🧩 Bölüm Yapısı

| Bölüm | Konu             | Açıklama                                                   |
|-------|------------------|------------------------------------------------------------|
| 1     | 1'den 10'a kadar | Çocuklara 1-10 arası sayılar öğretilir.                   |
| 2     | 10'dan geriye    | Geriye sayma becerisi kazandırılır.                        |
| 3     | Çift sayılar     | Sadece çift sayıdaki çiçekler toplanır.                    |
| 4     | Düzine           | 12’li grup sayma kavramı öğretilir.                        |
| 5     | Deste            | 10’lu grup sayma kavramı öğretilir.                        |
| 6     | Karışık          | Önceki bölümlerin birleşimi, düzine ve deste dahil edilir. |

## 🎨 Grafik & Ses Tasarımı
- **Stil:** Renkli, sade, dikkat dağıtmayan low poly modeller  
- **Çiçekler:** Papatya, menekşe, ayçiçeği vb.  
- **Ses:** Tatlı kadın/erkek sesiyle sesli sayım  
- **Müzik:** Çocuk dostu pozitif müzikler

## 🎯 Öğretici İçerikler
- Sayı tanıma ve sıralama
- Geriye sayma
- Grup sayma (düzine = 12, deste = 10)
- Konsantrasyon, dikkat
- Görsel-işitsel eşleştirme

## ⚙️ Teknik Bilgiler
- **AR Kit:** Unity AR Foundation + ARCore
- **Unity Versiyonu:** Unity 2022.3 LTS
- **Minimum Android Sürümü:** API 24 (Android 7.0)
- **Sahne Yapısı:**
  - `MainMenu`
  - `ARScene_Level1` → `ARScene_Level6`
  - `EndScreen`


## 🚀 Genişleme Potansiyeli
- Toplama / çıkarma oyunları
- Uzay / doğa temalı sahneler
- Multiplayer çocuk modu
