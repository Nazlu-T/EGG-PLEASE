using UnityEngine;

public class SellPoint : MonoBehaviour
{
    public int eggPrice = 5; 
    
    public void SellEggs(PlayerController player)
    {
        if (player.playerEggs > 0)
        {
            int eggsToSell = player.playerEggs; 
            int moneyGained = eggsToSell * eggPrice; 
            
            GameManager.Instance.money += moneyGained; 
            player.playerEggs = 0;                     
            player.UpdateInventoryUI();                
            
            Debug.Log($"{eggsToSell} Yumurta satıldı. Kazanılan Para: {moneyGained}$");
            
        }
        else
        {
            Debug.Log("Satılacak yumurtan yok!");
        }
    }
}