using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // ... [Mevcut Hız/Timer Değişkenleri] ...
    
    public bool hasEgg = false; // Toplanmayı bekleyen yumurta var mı?
    
    // ... [Start ve Update fonksiyonları aynı kalır] ...

    void LayEgg()
    {
        if (!hasEgg)
        {
            eggTimer = 0;
            hasEgg = true;
            Debug.Log("Tavuk yumurtladı, toplanmayı bekliyor.");
            // GÖRSEL İPUCU: Buraya yumurta sprite'ı/objesi eklenebilir.
        }
    }
    
    // YENİ ETKİLEŞİM METODU: PlayerController tarafından çağrılır
    public void Interact(PlayerController player)
    {
        if (hasEgg)
        {
            // 1. Yumurta Toplama
            player.playerEggs++;
            player.UpdateInventoryUI();
            hasEgg = false; // Yumurta alındı
            Debug.Log("Yumurta toplandı!");
            // GÖRSEL İPUCU: Yumurta görseli kaldırılır.
        }
        else if (hungerTimer >= timeToGetHungry)
        {
            // 2. Besleme
            if (player.playerCorn > 0)
            {
                player.playerCorn--; // Player envanterinden mısır harca
                player.UpdateInventoryUI();
                
                // Eski besleme mantığını çağır (büyüme, renk değişimi)
                FeedChicken(); 
                Debug.Log("Tavuk beslendi.");
            }
            else
            {
                Debug.Log("Mısırın yok!");
            }
        }
        else
        {
            Debug.Log("Tavuk doygun veya henüz yumurtlamadı.");
        }
    }
    
    // OnMouseDown fonksiyonunu bu scriptten tamamen kaldır.
    // ... [FeedChicken fonksiyonu ve diğerleri aynı kalır] ...
}