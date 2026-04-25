// Final
// DIG 3878
// Celine Hui
// Sarah Galindo
// This script allows the gem UI to keep track of the gems collected.

using UnityEngine;

public class GemUIManager : MonoBehaviour
{
    public static GemUIManager Instance { get; private set; }

    public int GemCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GemUIManager created and saved");
        }
        else
        {
            Debug.Log("Duplicate GemUIManager destroyed.");
            Destroy(gameObject);
        }
    }

    public void ResetGemCount()
    {
        Debug.Log("Gem count reset.");
        GemCount = 0;

    }

    public void AddGem()
    {
        GemCount++;
        Debug.Log("Gem count is now: " + GemCount);
    }
}
