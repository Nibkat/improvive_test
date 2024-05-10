using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactDistance = 2;

    [SerializeField] private string interactButtonName = "Fire1";
    public string InteractButtonName => interactButtonName;

    private bool _canInteract;
    public bool CanInteract => _canInteract;

    private Transform _camera;

    protected virtual void Start()
    {
        _camera = Camera.main.transform;
    }

    protected virtual void Update()
    {
        if (_canInteract && Input.GetButtonDown(interactButtonName))
        {
            OnInteract();
        }
    }

    protected virtual void FixedUpdate()
    {
        RaycastHit hit;

        _canInteract = Physics.Raycast(_camera.position, _camera.transform.forward, out hit, interactDistance);
    }

    protected virtual void OnInteract()
    {
        throw new System.NotImplementedException();
    }
}