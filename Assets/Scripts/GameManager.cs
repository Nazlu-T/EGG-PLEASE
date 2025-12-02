using UnityEngine;
using TMPro; // UI işlemleri için

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Küresel Ekonomi ve Kontrol")]
    public int money = 0; // Oyuncuların yumurta satarak kazandığı küresel para
    public bool godEventTriggered = false;

    [Header("Referanslar")]
    public GameObject chickenPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI globalMoneyText; // Global para birimini göstermek için
    
    // NOT: statsText kaldırıldı. Çünkü artık oyuncu envanterini PlayerController yönetiyor.

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Birden fazla GameManager olmasını engeller
    }

    void Update()
    {
        UpdateGlobalUI();
        CheckGodEvent();
    }

    // Küresel Para Arayüzünü güncelle
    void UpdateGlobalUI()
    {
        // inventoryText'ten farklı bir Text bileşeni kullanmalısın.
        if (globalMoneyText != null)
        {
            globalMoneyText.text = $"Para: {money}$";
        }
    }

    // Tanrısal Olay Kontrolü
    void CheckGodEvent()
    {
        // God Event şartını money (küresel para) üzerine kuralım.
        // Örnek: Toplam 25 Para kazandığında olay tetiklensin.
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
        // NOT: ChickenCount'u burada artırmak yerine, tavuk prefabının Start() fonksiyonunda sayımı artırması daha temiz olur.
    }
}