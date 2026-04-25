// Final
// DIG 3878
// Celine Hui
// This script allows the pea statues to rotate when the player interacts with them.

using UnityEngine;

public class RotateObject : MonoBehaviour, IInteractable
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float rotationAmount = 30f;
    [SerializeField] private Vector3 requiredRotation;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip statueSpinSound;

    private Quaternion objectRotation;
    private bool isRotating = false;
    private PuzzleManager manager;

    private void Start()
    {
        objectRotation = transform.rotation;
        manager = Object.FindAnyObjectByType<PuzzleManager>();
    }

    public void Interact(Transform player, Transform inspectPoint)
    {
        objectRotation *= Quaternion.Euler(0f, rotationAmount, 0f);
        isRotating = true;
        audioSource.PlayOneShot(statueSpinSound);
    }

    public void StopInteract() { }

    public bool RequiresInspection()
    {
        return false;
    }

    private void Update()
    {   
        if (!GameStateManager.Instance.IsGameplay())
        {
            return;
        }


        if (isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, objectRotation, Time.deltaTime * rotationSpeed);
            
            if (Quaternion.Angle(transform.rotation, objectRotation) < 0.1f)
            {
                transform.rotation = objectRotation;
                isRotating = false;

                if (manager)
                {
                    manager.CheckStatuePuzzle();
                }
            }
        }
    }

    public bool IsAligned()
    { 
        return Quaternion.Angle(transform.rotation, Quaternion.Euler(requiredRotation)) < 0.1f;
    }


}
