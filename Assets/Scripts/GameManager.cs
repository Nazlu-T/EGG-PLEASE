using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("Ekonomi")]
    public int cornAmount = 0;
    public int eggAmount = 0;
    public int money = 0;

    [Header("Oyun Durumu")]
    public int chickenCount = 2;
    public bool godEventTriggered = false;

    [Header("Referanslar")]
    public GameObject chickenPrefab; 
    public Transform spawnPoint; // Tavuğun doğacağı yer (Void'den gelen)
    public TextMeshProUGUI statsText; 

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Update()
    {
        UpdateUI();
        CheckGodEvent();
    }

    // Arayüzü güncelle
    void UpdateUI()
    {
        statsText.text = $"Mısır: {cornAmount} | Yumurta: {eggAmount} | Para: {money}$";
    }

    // Tanrısal Olay Kontrolü
    void CheckGodEvent()
    {
        // Örnek Şart: 5 Yumurta topladığında olay tetiklensin
        if (!godEventTriggered && eggAmount >= 5)
        {
            TriggerGodEvent();
        }
    }

    void TriggerGodEvent()
    {
        godEventTriggered = true;
        Debug.Log("God Dialog");
        
        // Yeni tavuğu yarat (God Chicken)
        Instantiate(chickenPrefab, spawnPoint.position, Quaternion.identity);
        chickenCount++;
        
        // Buraya ileride ekran titremesi veya ses efekti ekleyebilirsin
    }
}