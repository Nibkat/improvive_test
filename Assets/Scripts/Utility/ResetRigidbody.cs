using UnityEngine;

public class ResetRigidbody : MonoBehaviour
{
    [SerializeField] private float yCutoff = -20;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y <= yCutoff)
        {
            _rigidbody.velocity = Vector3.zero;
            transform.position = _startPosition;
        }
    }
}