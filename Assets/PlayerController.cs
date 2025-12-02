using UnityEngine;
using TMPro; 

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
    
    
    private Collider2D currentInteractable = null; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateInventoryUI();
    }

    void Update()
    {
        // 1. Girişler 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // 2. Etkileşim Tuşu 
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            TryInteract();
        }
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Corn"))
        {
            other.GetComponent<CornCollectible>().Collect(this); 
        }
        
        
        else if (other.CompareTag("Chicken") || other.CompareTag("SellPoint"))
        {
            currentInteractable = other;
            Debug.Log("Etkileşime hazır. 'E' bas.");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Etkileşim bölgesinden çıkıldı.");
        }
    }

   
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

        public void UpdateInventoryUI()
    {
        inventoryText.text = $"Mısır: {playerCorn}\nYumurta: {playerEggs}";
    }
}
