using Unity.VisualScripting;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool isAlive = true;

    [SerializeField] private float _flapStrength = 7f;
    [SerializeField] private float _rotationSpeed = 2.5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAlive && Time.timeScale > 0)
        {
            _rb.linearVelocity = Vector2.up * _flapStrength;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        GameOverManager.Instance.TriggerGameOver();
    }
}
