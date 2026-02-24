using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {

        if (BirdMovement.Instance != null && BirdMovement.Instance.IsAlive)
        {

            transform.position += Vector3.left * _speed * Time.unscaledDeltaTime;
        }
    }
}