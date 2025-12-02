using UnityEngine;

public class CornCollectible : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.Instance.cornAmount++;
        Destroy(gameObject); // Mısırı sahneden yok et (Toplandı)
    }
}