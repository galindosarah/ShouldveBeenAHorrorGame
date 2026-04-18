using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    public int[] correctSequence; 
    public GameObject gemObject;

    private int currentStep = 0;
    private bool puzzleSolved = false;

    private void Start()
    {
        if (gemObject != null)
        {
            gemObject.SetActive(false); // hide gem at start
        }
    }

    public void PlatePressed(int plateID)
    {
        if (puzzleSolved) return;

        // Check if the pressed plate matches the expected one
        if (plateID == correctSequence[currentStep])
        {
            currentStep++;
            Debug.Log("Correct plate! Step: " + currentStep);

            // If all steps are completed
            if (currentStep >= correctSequence.Length)
            {
                SolvePuzzle();
            }
        }
        else
        {
            Debug.Log("Wrong plate. Resetting sequence.");
            ResetSequence();
        }
    }

    private void SolvePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Puzzle solved!");

        if (gemObject != null)
        {
            gemObject.SetActive(true);
        }
    }

    public void ResetSequence()
    {
        currentStep = 0;
    }
}