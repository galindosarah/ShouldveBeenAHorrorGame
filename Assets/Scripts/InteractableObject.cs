using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Collider col;
    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        col = GetComponent<Collider>();
        originalParent = transform.parent;
    }

    public void Interact(Transform inspectPoint)
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        if (col != null)
        {
            col.enabled = false;
        }

        transform.SetParent(inspectPoint);
        transform.position = inspectPoint.position;
        transform.rotation = inspectPoint.rotation;
    }

    public void StopInteract()
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        if (col != null)
        {
            col.enabled = true;
        }
    }
}
