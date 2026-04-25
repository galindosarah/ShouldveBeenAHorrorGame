// Final
// DIG 3878
// Celine Hui
// Sarah Galindo
// This script allows the gems collected to be shown on screen. 

using UnityEngine;
using UnityEngine.UI;

public class GemUI : MonoBehaviour
{
    public Image[] gems;
    public Sprite heartCollected;
    public Sprite heartEmpty;


    private void Update()
    {
        if (GemUIManager.Instance == null)
        {
            return;
        }

        if (GameStateManager.Instance != null && !GameStateManager.Instance.IsGameplay())
        {
            return;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {

        int gemCount = GemUIManager.Instance.GemCount;
        for (int i = 0; i < gems.Length; i++)
        {
            if (i < gemCount)
            {
                gems[i].sprite = heartCollected;
            }
            else
            {
                gems[i].sprite = heartEmpty;
            }
        }
    }
}
