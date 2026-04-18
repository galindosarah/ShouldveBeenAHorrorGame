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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetGemCount()
    {
        GemCount = 0;
    }
}
