using UnityEngine;

public class RepeatingGround : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _width; // Bir tile'ın tam genişliği (Örn: 20)

    void Update()
    {
        // Sadece kuş hayattaysa hareket et
        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {
            // Sola doğru kaydır
            transform.position += Vector3.left * _speed * Time.unscaledDeltaTime;
        }

        // Işınlanma Kontrolü:
        // Eğer tile, kendi genişliği kadar sola gittiyse
        if (transform.position.x <= -_width)
        {
            // DİKKAT: Pozisyonu eşitlemiyoruz, mevcut pozisyonuna 
            // iki tile'ın toplam genişliğini EKLEYEREK sağa atıyoruz.
            // Bu sayede aradaki milimetrik kaymalar (hata payı) korunur ve boşluk oluşmaz.
            transform.position += Vector3.right * (_width * 2f);
        }
    }
}