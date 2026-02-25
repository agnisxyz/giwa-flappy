using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float width = 20f;

    void Update()
    {
        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {
            transform.position += Vector3.left * speed * Time.unscaledDeltaTime;
        }

        if (transform.position.x <= -width)
        {

            float overlap = 0.1f;
            transform.position += Vector3.right * ((width * 2f) - overlap);
        }
    }
}