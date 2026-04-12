using UnityEngine;

public class InspectObject : MonoBehaviour, IInteractable
{
    private Collider col;

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    private Transform inspectPoint;

    [SerializeField] private Vector3 rotationOffset;
    [SerializeField] private Vector3 scaleOffset = Vector3.one;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void Interact(Transform player, Transform inspectPoint)
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalParent = transform.parent;
        originalScale = transform.localScale;

        if (col)
        {
            col.enabled = false;
        }

        transform.SetParent(inspectPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        transform.localScale = scaleOffset;
    }

    public void StopInteract()
    {   
        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        if (col)
        {
            col.enabled = true;
        }
    }

    public bool RequiresInspection()
    {
        return true;
    }
}
