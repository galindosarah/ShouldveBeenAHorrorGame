// Final
// DIG 3878
// Annette Gonzalez
// Sarah Galindo
// Celine Hui
// This script allows the player to interact with interactable object and recieve a prompt to do so.

using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private Transform inspectPoint;

    private IInteractable currentInteractable;
    private bool isInspecting;

    void Start() 
    { 
        interactPrompt.SetActive(false);
        closeButton.SetActive(false);
    }

    void Update()
    {
        if (GameStateManager.Instance.IsPaused())
            return;

        if (GameStateManager.Instance.IsInspecting())
        {
            return;
        }

        TryInteract();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            StartInteraction();
        }
    }

    void TryInteract()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {   
            //Debug.Log("Hit: " + hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null) 
            { 
                currentInteractable = interactable;
                interactPrompt.SetActive(true);
                return;
            }

            //hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
        }
        currentInteractable = null;
        interactPrompt.SetActive(false);
    }

    void StartInteraction()
    {
        currentInteractable.Interact(transform, inspectPoint);

        interactPrompt.SetActive(false);

        isInspecting = currentInteractable.RequiresInspection();

        if (isInspecting)
        {
            GameStateManager.Instance.SetState(GameState.Inspecting);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            closeButton.SetActive(true);
        }
    }

    public void StopInteraction()
    {
        if (currentInteractable != null)
        {
            currentInteractable.StopInteract();
        }

        currentInteractable = null;
        isInspecting = false;

        closeButton.SetActive(false);

        GameStateManager.Instance.SetState(GameState.Gameplay);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
