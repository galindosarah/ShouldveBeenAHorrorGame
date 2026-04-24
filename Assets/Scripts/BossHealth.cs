// DIG3878
// Sarah Galindo
// Annette Gonzalez
// This script allows the boss to take damage and disappear once health is lost.

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 7;
    private int currentHealth;

    public string winSceneName;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log("Boss HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject);
        SceneManager.LoadScene(winSceneName);
    }
}
