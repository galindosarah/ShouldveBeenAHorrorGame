using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime = 3f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
