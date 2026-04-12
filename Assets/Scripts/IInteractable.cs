using UnityEngine;

public interface IInteractable
{
    void Interact(Transform player, Transform inspectPoint);
    void StopInteract();
    bool RequiresInspection();
}
