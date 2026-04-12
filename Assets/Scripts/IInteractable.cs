using UnityEngine;

public interface IInteractable
{
    public void Interact(Transform player, Transform inspectPoint);
    public void StopInteract();
    public bool RequiresInspection();
}
