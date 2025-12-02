using UnityEngine;

public class CornCollectible : MonoBehaviour
{
    // OnMouseDown kaldırıldı. PlayerController tarafından çağrılacak.
    public void Collect(PlayerController player)
    {
        player.playerCorn++;          // Player'ın envanterine ekle
        player.UpdateInventoryUI();   // Arayüzü güncelle
        
        Destroy(gameObject);          // Mısırı sahneden yok et
    }
}