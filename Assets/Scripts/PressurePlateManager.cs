// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script allows the pressure plates to be pressed in a certain sequence to complete the puzzle.

using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    public int[] correctSequence;
    public PressurePlate[] allPlates;

    public GameObject gemPrefab;
    public Transform gemSpawnPoint;

    private int currentStep = 0;
    private bool puzzleSolved = false;

    public AudioSource audioSource;
    public AudioClip heartSpawnSound;
    public AudioClip platePressSound;

    public void PlatePressed(int plateID)
    {
        if (puzzleSolved) return;

        audioSource.PlayOneShot(platePressSound);

        if (plateID == correctSequence[currentStep])
        {
            currentStep++;
            Debug.Log("Correct plate! Step: " + currentStep);

            if (currentStep >= correctSequence.Length)
            {
                SolvePuzzle();
            }
        }
        else
        {
            Debug.Log("Wrong plate. Resetting puzzle.");
            ResetSequence();
        }
    }

    void SolvePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Puzzle solved!");

        if (gemPrefab != null && gemSpawnPoint != null)
        {
            Instantiate(gemPrefab, gemSpawnPoint.position, gemSpawnPoint.rotation);
            audioSource.PlayOneShot(heartSpawnSound);
        }
    }

    public void ResetSequence()
    {
        currentStep = 0;

        foreach (PressurePlate plate in allPlates)
        {
            if (plate != null)
            {
                plate.ResetPlate();
            }
        }
    }
}