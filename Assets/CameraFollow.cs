using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Hedef Obje")]
    public Transform target; // Oyuncu objesinin Transform bileşeni

    [Header("Ayarlar")]
    public float smoothSpeed = 0.125f; // Takip yumuşaklığı (küçük değerler daha yavaş takip eder)
    public Vector3 offset = new Vector3(0, 0, -10); // Kamera ile oyuncu arasındaki mesafe (Z ekseni -10 olmalı)

    void FixedUpdate()
    {
        if (target == null) return; // Oyuncu yoksa hata verme

        // 1. Kameranın Gitmek İstediği Konum
        // Oyuncunun konumu + Ofset (Kameranın Z'si genelde -10'dur)
        Vector3 desiredPosition = target.position + offset;

        // 2. Yumuşak Geçiş (Lerp)
        // Kamerayı aniden değil, yumuşak bir şekilde istenen konuma hareket ettirir.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 3. Konumu Uygula
        transform.position = smoothedPosition;
    }
}