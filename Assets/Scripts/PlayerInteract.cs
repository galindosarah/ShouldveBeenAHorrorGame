using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        } 
    }

    void TryInteract()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
        }
    }
}
