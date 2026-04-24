// Midterm
// DIG3878
// Annette Gonzalez
// This script increases the scene light brightness.

using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light caveLight;
    [SerializeField] private float brightnessIncrease = 0.2f;
    
    public void IncreaseLight()
    {
        caveLight.intensity += brightnessIncrease;
    }
}
