using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public static BirdMovement Instance;

    private Rigidbody2D _rb;
    public bool IsAlive = true;

    [Header("Movement Settings")]
    [SerializeField] private float _flapStrength = 7f;
    [SerializeField] private float _rotationSpeed = 2.5f;
    [SerializeField] private float _upperBoundary = 4.5f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. ANA MENÜ DURUMU: Oyun duruyorken ve kuş hayattayken süzül
        if (Time.timeScale == 0 && IsAlive)
        {
            float yOffset = Mathf.Sin(Time.unscaledTime * 4f) * 0.15f;
            transform.position = new Vector3(0, yOffset, 0);
            return;
        }

        // 2. OYUN DURUMU: Kuş hayattaysa ve zaman akıyorsa zıpla
        if (IsAlive && Time.timeScale > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb.linearVelocity = Vector2.up * _flapStrength;
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.FlapSound);
            }

            // Üst sınır kontrolü
            if (transform.position.y > _upperBoundary)
            {
                transform.position = new Vector3(transform.position.x, _upperBoundary, transform.position.z);
                _rb.linearVelocity = Vector2.zero;
            }
        }

        // 3. ÖLÜM DURUMU: IsAlive false olduğu an yukarıdaki hiçbir kod çalışmaz, 
        // ne yaylanma yapılır ne de zıplanır.
    }

    void FixedUpdate()
    {
        if (IsAlive && Time.timeScale > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            IsAlive = false;
            GameOverManager.Instance.TriggerGameOver();
        }
    }
}