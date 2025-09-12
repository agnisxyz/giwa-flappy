using Unity.VisualScripting;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _flapStrength = 7f;
    [SerializeField] private float _rotationSpeed = 2.5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.linearVelocity = Vector2.up * _flapStrength;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }
}
