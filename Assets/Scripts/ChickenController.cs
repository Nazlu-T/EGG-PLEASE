using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [Header("Durum")]
    public bool isAdult = false;
    public float hungerTimer = 0f;
    public float eggTimer = 0f;

    [Header("Ayarlar")]
    public float timeToGetHungry = 10f; // 10 saniyede bir acıkır
    public float timeToLayEgg = 5f;     // 5 saniyede bir yumurtlar (Yetişkinse)
    
    // Görsel değişim için (Renk veya Sprite)
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // Bebek tavuk küçük başlar
        transform.localScale = new Vector3(0.5f, 0.5f, 1f); 
    }

    void Update()
    {
        // 1. Acıkma Mantığı
        hungerTimer += Time.deltaTime;
        if(hungerTimer >= timeToGetHungry)
        {
            // Acıktı görseli (Örn: Rengi kırmızılaşır)
            sr.color = Color.red; 
        }

        // 2. Yumurtlama Mantığı (Sadece yetişkinse ve aç değilse)
        if (isAdult && hungerTimer < timeToGetHungry)
        {
            eggTimer += Time.deltaTime;
            if (eggTimer >= timeToLayEgg)
            {
                LayEgg();
                eggTimer = 0;
            }
        }
    }

    // Tavuğa tıklandığında (Besleme)
    void OnMouseDown()
    {
        // Eğer oyuncunun mısırı varsa ve tavuk açsa
        if (GameManager.Instance.cornAmount > 0)
        {
            FeedChicken();
        }
    }

    void FeedChicken()
    {
        GameManager.Instance.cornAmount--; // Mısır harca
        hungerTimer = 0; // Karnı doydu
        sr.color = Color.white; // Rengi düzeldi
        
        // Eğer bebekse büyüsün
        if (!isAdult)
        {
            isAdult = true;
            transform.localScale = Vector3.one; // Normal boyuta dön
            Debug.Log("Tavuk Büyüdü!");
        }
    }

    void LayEgg()
    {
        GameManager.Instance.eggAmount++;
        Debug.Log("Yumurta geldi!");
        // İstersen buraya 'Instantiate' ile yere fiziksel yumurta düşürebilirsin.
    }
}
