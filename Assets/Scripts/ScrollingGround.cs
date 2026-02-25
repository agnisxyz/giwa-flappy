using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _width = 20f;

    void Update()
    {

        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {
            transform.position += Vector3.left * _speed * Time.unscaledDeltaTime;
        }


        if (transform.position.x <= -_width)
        {

            float overlap = 0.1f;
            transform.position += Vector3.right * ((_width * 3f) - overlap);
        }
    }
}