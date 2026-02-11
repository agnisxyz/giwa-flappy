using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool IsAlive = true;

    [SerializeField] private float _flapStrength = 7f;
    [SerializeField] private float _rotationSpeed = 2.5f;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // This function will be called by GameOverManager to reset the bird
    public void ResetBird()
    {
        IsAlive = true;
        transform.position = Vector3.zero; // Moves bird to center
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
            // Play the flap sound
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