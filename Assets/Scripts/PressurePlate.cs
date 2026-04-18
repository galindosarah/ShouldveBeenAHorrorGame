using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int plateID;
    public PressurePlateManager sequenceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sequenceManager.PlatePressed(plateID);
        }
    }
}