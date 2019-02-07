using UnityEngine;

public class IgnorePlayerCollider : MonoBehaviour
{
    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindWithTag("Player").GetComponent<Collider>());
    }
}
