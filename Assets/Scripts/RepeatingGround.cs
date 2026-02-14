using UnityEngine;

public partial class RepeatingGround : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _otherTile;
    [SerializeField] private float _overlapAmount = 0.05f; // Boşluğu kapatmak için üst üste binme payı

    private float _width;
    private Camera _mainCamera;

    void Start()
    {
        // Sprite'ın tam genişliğini Renderer bileşeninden alıyoruz
        _width = GetComponentInChildren<Renderer>().bounds.size.x;
        _mainCamera = Camera.main;

    }

    void Update()
    {
        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {
            transform.position += Vector3.left * _speed * Time.unscaledDeltaTime;
        }

        // Kameranın sol sınırını dünya koordinatlarında hesapla
        float cameraLeftEdge = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        // Objenin sağ kenar pozisyonunu hesapla
        float spriteRightEdge = transform.position.x + (_width / 2f);

        // Eğer objenin sağ kenarı kameranın solundan çıkmışsa ışınla
        if (spriteRightEdge < cameraLeftEdge)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        // Boşluk kalmaması için diğer tile'ın bittiği yere, overlap payı kadar geriden ekle
        transform.position = new Vector3(
            _otherTile.position.x + _width - _overlapAmount,
            transform.position.y,
            transform.position.z
        );
    }
}