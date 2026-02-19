using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    // HATA ÇÖZÜMÜ: Bu satırı ekleyerek 'Instance' ismini tanımlıyoruz
    public static BirdMovement Instance;

    private Rigidbody2D _rb;
    public bool IsAlive = true;

    [SerializeField] private float _flapStrength = 7f;
    [SerializeField] private float _rotationSpeed = 2.5f;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

        _rb = GetComponent<Rigidbody2D>();
    }


    public void ResetBird()
    {
        IsAlive = true;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rb.linearVelocity = Vector2.zero;
        _rb.simulated = true;
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetMouseButtonDown(0) && IsAlive)
        {
            _rb.linearVelocity = Vector2.up * _flapStrength;
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFX(AudioManager.Instance.FlapSound);
        }
    }

    void FixedUpdate()
    {
        if (IsAlive)
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            IsAlive = false;
            if (GameOverManager.Instance != null)
            {
                GameOverManager.Instance.TriggerGameOver();
            }
        }
    }
}