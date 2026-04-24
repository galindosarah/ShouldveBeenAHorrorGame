// Midterm
// DIG3878
// Annette Gonzalez
// This script allows the brightness of the scene to increase every time a crystal is collected.

using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private LightManager lightManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightManager.IncreaseLight();

            Destroy(gameObject);
        }
    }
}
