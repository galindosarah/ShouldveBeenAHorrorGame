// DIG3878
// Sarah Galindo
// Annette Gonzalez
// This script allows the boss to take damage and disappear once health is lost.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class BossHealth : MonoBehaviour
{
    public int maxHealth = 6;
    private int currentHealth;

    public Image[] bananas;
    public Sprite fullBanana;
    public Sprite emptyBanana;

    public string winSceneName;

    public AudioClip damageSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        AudioSource.PlayClipAtPoint(damageSound, transform.position);
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Boss HP: " + currentHealth);

        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < bananas.Length; i++)
        {
            if (i < currentHealth)
            {
                bananas[i].sprite = fullBanana;
            }
            else
            {
                bananas[i].sprite = emptyBanana;
            }
        }
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject);
        SceneManager.LoadScene(winSceneName);
    }

}
