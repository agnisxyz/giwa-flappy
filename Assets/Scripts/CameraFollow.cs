using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetX = 2f;

    void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = new Vector3(
                _target.position.x + _offsetX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
