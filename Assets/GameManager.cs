using UnityEngine;
using TMPro; // UI işlemleri için

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Küresel Ekonomi ve Kontrol")]
    public int money = 0; // Oyuncuların yumurta satarak kazandığı küresel para
    public bool godEventTriggered = false;
    public int chickenCount = 2; // Başlangıç sayısını takip et

    [Header("Referanslar")]
    public GameObject chickenPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI globalMoneyText; // Global parayı göstermek için

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        UpdateGlobalUI();
        CheckGodEvent();
    }

    void UpdateGlobalUI()
    {
        if (globalMoneyText != null)
        {
            globalMoneyText.text = $"Para: {money}$";
        }
    }

    void CheckGodEvent()
    {
        // Örnek: Toplam 25 Para kazanıldığında olay tetiklensin.
        if (!godEventTriggered && money >= 25)
        {
            TriggerGodEvent();
        }
    }

    void TriggerGodEvent()
    {
        godEventTriggered = true;
        Debug.Log("GÖKLERDEN GELEN BİR KARAR VARDIR...");

        Instantiate(chickenPrefab, spawnPoint.position, Quaternion.identity);
        chickenCount++; 
        // Burada görsel efektler/sesler eklenebilir.
    }
}