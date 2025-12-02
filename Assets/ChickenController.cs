using UnityEngine;

public class ChickenController : MonoBehaviour
{
   
    [Header("Durum ve Zamanlayıcılar")]
    public bool isAdult = false;
    public bool hasEgg = false; 
    
   
    public float hungerTimer = 0f;      
    public float eggTimer = 0f;        
    [Header("Ayarlar")]

    public float timeToGetHungry = 10f; 
    public float timeToLayEgg = 5f;     
    private SpriteRenderer sr;          
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }
       

    void Update()
    {
        // 1. Acıkma Mantığı
        hungerTimer += Time.deltaTime;
        if(hungerTimer >= timeToGetHungry)
        {
            // Acıktı görseli
            if (sr.color != Color.red) sr.color = Color.red; 
        }

        // 2. Yumurtlama
        if (isAdult && hungerTimer < timeToGetHungry && !hasEgg)
        {
            eggTimer += Time.deltaTime;
            if (eggTimer >= timeToLayEgg)
            {
                LayEgg();
            }
        }
    }

    void LayEgg()
    {
        eggTimer = 0;
        hasEgg = true;
        Debug.Log("Tavuk yumurtladı, toplanmayı bekliyor.");
    }
        
    public void Interact(PlayerController player)
    {
        if (hasEgg)
        {
            // 1. Yumurta Toplama
            //player.AddEgg(1);
            player.UpdateInventoryUI();
            hasEgg = false; // Yumurta alındı
            Debug.Log("Yumurta toplandı!");
           
        }
        else if (hungerTimer >= timeToGetHungry)
        {
            // 2. Besleme
            if (player.playerCorn > 0)
            {
                player.playerCorn--; // Player envanterinden mısır harca
                player.UpdateInventoryUI();
                
                // Besleme mantığını çağır
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
    
    void FeedChicken() 
    {
        hungerTimer = 0; // Karnı doydu
        sr.color = Color.white; // Rengi düzeldi
        
      
        if (!isAdult)
        {
            isAdult = true;
           
            transform.localScale = Vector3.one; 
            Debug.Log("Tavuk Büyüdü!");
        }
    }
}

