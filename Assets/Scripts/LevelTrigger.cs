// Final
// DIG 3878
// Annette Gonzalez
// This script allows the player to load the next scene after making contact with the door.

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public string nextSceneName = "Level2Scene";

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
