// Final
// DIG 3878
// Celine Hui
// This script is an interface for interactable objects.

using UnityEngine;

public interface IInteractable
{
    void Interact(Transform player, Transform inspectPoint);
    void StopInteract();
    bool RequiresInspection();
}
