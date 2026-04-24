// DIG 3878
// Annette Gonzalez
// This script allows the gem hearts to turn into the player's health and will play the gameover screen
// when the player loses all three hearts.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public string gameOverSceneName = "GameOver";

    private bool canTakeDamage = true;
    public float damageCooldown = 1f;

    void Start()
    {
        if (GemUIManager.Instance != null)
        {
            currentHearts = GemUIManager.Instance.GemCount;
        }
        else
        {
            currentHearts = 1;
        }

        currentHearts = Mathf.Clamp(currentHearts, 1, maxHearts);
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        if (!canTakeDamage) return;

        canTakeDamage = false;
        Invoke(nameof(ResetDamage), damageCooldown);

        currentHearts -= amount;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);

        UpdateUI();

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    void ResetDamage()
    {
        canTakeDamage = true;
    }

    void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i< currentHearts)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
