using UnityEngine;

public class RepeatingGround : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _otherTile;

    private Renderer _renderer;
    private bool _hasStarted = false;

    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        // Başlangıçta bir frame geçmeden ışınlama olmasın
        Invoke(nameof(EnableLoop), 0.1f);
    }

    void Update()
    {
        // sola kaydır
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (_hasStarted && _renderer.isVisible == false)
        {
            float _width = _renderer.bounds.size.x;
            transform.position = new Vector3(
                _otherTile.position.x + _width - 0.5f,
                transform.position.y,
                transform.position.z
            );
        }
    }

    private void EnableLoop()
    {
        _hasStarted = true;
    }
}

















