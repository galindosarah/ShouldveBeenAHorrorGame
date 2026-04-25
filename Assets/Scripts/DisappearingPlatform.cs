// Final
// DIG 3878
// Annette Gonzalez
// This script allows the platforms to disappear after a certain amount of time of contact with player.

using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float timeBeforeDisappear = 2f;
    public float respawnDelay = 2f;

    private float timer = 0f;
    private bool playerOnPlatform = false;
    private bool isHidden = false;

    private Collider col;
    private Renderer rend;

    void Start()
    {
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (playerOnPlatform && !isHidden)
        {
            timer += Time.deltaTime;

            if (timer >= timeBeforeDisappear)
            {
                HidePlatform();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            timer = 0f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            timer = 0f;

            if (isHidden)
            {
                Invoke(nameof(ShowPlatform), respawnDelay);
            }
        }
    }

    void HidePlatform()
    {
        isHidden = true;
        playerOnPlatform = false;

        col.enabled = false;
        rend.enabled = false;

        Invoke(nameof(ShowPlatform), respawnDelay);
    }

    void ShowPlatform()
    {
        isHidden = false;
        timer = 0f;

        col.enabled = true;
        rend.enabled = true;
    }
}
