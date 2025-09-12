using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;  // Kuşun transform’u
    [SerializeField] private float _offsetX = 2f; // Kuşun kameranın biraz önünde görünmesi için

    void Update()
    {
        if (_target != null)
        {
            transform.position = new Vector3(
                _target.position.x + _offsetX,   // X ekseninde kuşu takip et
                transform.position.y,           // Y sabit kalsın
                transform.position.z            // Z sabit kalsın (kamera derinliği)
            );
        }
    }
}
