using UnityEngine;

public class SellPoint : MonoBehaviour
{
    public int eggPrice = 5; // Bir yumurtanın satış fiyatı
    
    // PlayerController tarafından 'E' tuşuna basılınca çağrılır
    public void SellEggs(PlayerController player)
    {
        if (player.playerEggs > 0)
        {
            int eggsToSell = player.playerEggs; // Elindeki tüm yumurtaları sat
            int moneyGained = eggsToSell * eggPrice; 
            
            GameManager.Instance.money += moneyGained; // Global paraya ekle
            player.playerEggs = 0;                     // Player envanterini sıfırla
            player.UpdateInventoryUI();                // Player arayüzünü güncelle
            
            Debug.Log($"{eggsToSell} Yumurta satıldı. Kazanılan Para: {moneyGained}$");
            // GameManager'daki ana arayüzü de güncellemek gerekebilir.
        }
        else
        {
            Debug.Log("Satılacak yumurtan yok!");
        }
    }
}