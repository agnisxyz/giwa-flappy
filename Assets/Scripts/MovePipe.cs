using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        //st
    }
}
