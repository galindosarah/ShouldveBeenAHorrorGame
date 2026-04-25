// Final
// DIG3878
// Annette Gonzalez
// This script allows the fireball to last for a certain amount of time.

using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime = 3f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
