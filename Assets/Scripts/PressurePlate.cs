// Final
// DIG 3878
// Sarah Galindo
// This script allows the player to interact with the pressure plates.

using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int plateID;
    public PressurePlateManager sequenceManager;

    public Renderer plateRenderer;
    public Material[] defaultMaterials;
    public Material[] pressedMaterials;

    public float pressDepth = 0.1f;
    public float pressSpeed = 4f;

    private Vector3 originalPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;

    void Start()
    {
        originalPosition = transform.position;
        pressedPosition = originalPosition + Vector3.down * pressDepth;

        if (plateRenderer != null && defaultMaterials != null && defaultMaterials.Length > 0)
        {
            plateRenderer.materials = defaultMaterials;
        }
    }

    void Update()
    {
        if (isPressed)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                pressedPosition,
                Time.deltaTime * pressSpeed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;

            if (plateRenderer != null && pressedMaterials != null && pressedMaterials.Length > 0)
            {
                plateRenderer.materials = pressedMaterials;
            }

            sequenceManager.PlatePressed(plateID);
        }
    }

    public void ResetPlate()
    {
        isPressed = false;
        transform.position = originalPosition;

        if (plateRenderer != null && defaultMaterials != null && defaultMaterials.Length > 0)
        {
            plateRenderer.materials = defaultMaterials;
        }
    }
}