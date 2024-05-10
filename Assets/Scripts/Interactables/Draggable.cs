using UnityEngine;

public class Draggable : Interactable
{
    private Rigidbody _rigidbody;

    private bool _isDragging;
    private Transform _dragTarget;

    // physics variables
    [SerializeField] private float toVelocity = 5f;
    [SerializeField] private float maxVelocity = 15.0f;
    [SerializeField] private float maxForce = 40.0f;
    [SerializeField] private float gain = 5f;
    [SerializeField] private float throwForce = 10;

    protected override void Start()
    {
        base.Start();

        _rigidbody = GetComponent<Rigidbody>();

        _dragTarget = GameObject.FindWithTag("DragTarget").transform;
    }

    protected override void Update()
    {
        // drop the object if the player is too far away
        if (Vector3.Distance(transform.position, _dragTarget.position) > 3)
        {
            _rigidbody.useGravity = true;
            _isDragging = false;
        }

        if (_isDragging && Input.GetButtonDown(base.InteractButtonName))
        {
            // stop dragging the object
            _rigidbody.useGravity = true;
            _isDragging = false;

            // add force to throw the object
            _rigidbody.AddForce(_dragTarget.forward * throwForce, ForceMode.Impulse);
        }
        else
        {
            base.Update();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_isDragging)
        {
            Drag();
        }
    }

    protected override void OnInteract()
    {
        if (!_isDragging)
        {
            _rigidbody.useGravity = false;
            _isDragging = true;
        }
    }
    
    private void Drag()
    {
        Vector3 distance = _dragTarget.position - transform.position;
        // calculate a target vel proportional to distance (clamped to maxVel)
        Vector3 targetVelocity = Vector3.ClampMagnitude(toVelocity * distance, maxVelocity);
        // calculate the velocity error
        Vector3 error = targetVelocity - _rigidbody.velocity;
        // calculate a force proportional to the error (clamped to maxForce)
        Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
        _rigidbody.AddForce(force);
    }
}