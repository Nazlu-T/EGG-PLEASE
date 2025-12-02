using UnityEngine;
using TMPro; // UI için

public class PlayerController : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    [Header("Envanter")]
    public int playerCorn = 0;
    public int playerEggs = 0;
    
    [Header("UI Referansları")]
    public TextMeshProUGUI inventoryText;
    
    // Etkileşimde olunan objeyi tutmak için geçici değişken
    private Collider2D currentInteractable = null; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateInventoryUI();
    }

    void Update()
    {
        // 1. Girişler (Input)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // 2. Etkileşim Tuşu (Örn: E tuşu)
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            TryInteract();
        }
    }

    void FixedUpdate()
    {
        // Fizik motoru ile hareket
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
    // ----------------------------------------------------
    // KAYNAK TOPLAMA ve ETKİLEŞİM BÖLÜMÜ
    // ----------------------------------------------------
    
    // Oyuncu bir Tetikleyiciye (Trigger) girdiğinde
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Corn (Mısır): Dokunmak yeterli, otomatik toplansın.
        if (other.CompareTag("Corn"))
        {
            other.GetComponent<CornCollectible>().Collect(this); // Mısır scriptini çağır
        }
        
        // Diğer objeler (Tavuk, Satış Kutusu) için sadece hedefi kaydet
        else if (other.CompareTag("Chicken") || other.CompareTag("SellPoint"))
        {
            currentInteractable = other;
            Debug.Log("Etkileşime hazır. 'E' bas.");
        }
    }

    // Oyuncu bir Tetikleyiciden çıktığında
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Etkileşim bölgesinden çıkıldı.");
        }
    }

    // 'E' tuşuna basılınca ne yapılacağını belirleyen ana fonksiyon
    void TryInteract()
    {
        if (currentInteractable.CompareTag("Chicken"))
        {
            currentInteractable.GetComponent<ChickenController>().Interact(this);
        }
        else if (currentInteractable.CompareTag("SellPoint"))
        {
            currentInteractable.GetComponent<SellPoint>().SellEggs(this);
        }
    }

    // Public Metotlar (Başka scriptler buraya yumurta/mısır eklemek için çağırır)
    public void UpdateInventoryUI()
    {
        inventoryText.text = $"Mısır: {playerCorn}\nYumurta: {playerEggs}";
    }
}
