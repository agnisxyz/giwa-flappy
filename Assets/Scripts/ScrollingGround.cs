using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed = 4f;

    private float spriteWidth;

    void Start()
    {

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {

        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {

            transform.position += Vector3.left * _speed * Time.unscaledDeltaTime;
        }


        if (transform.position.x <= -spriteWidth)
        {

            transform.position += Vector3.right * ((spriteWidth * 2f) - 0.1f);
        }
    }
}