using System.Collections;
using UnityEngine;
using DigitalWorlds;

public class PuzzleManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints;

    public int targetsRemaining;
    public bool playerOnCarpet = false;

    public Transform carpet;
    public float liftHeight = 10f;
    public float liftSpeed = 2f;

    public Camera playerCamera;
    public Camera[] previewCameras;
    public float previewTime = 1.5f;

    private bool lifting = false;
    private bool allTargetsDestroyed = false;
    private bool started = false;

    public RigidbodyFPSController playerController;

    public PlayerInteract playerInteract;
    // public MonoBehaviour playerLookScript; // assign your look script here if needed

    public void StartPuzzle()
    {
        if (started) return;

        started = true;
        SpawnTargets();
        StartCoroutine(ShowTargetsSequence());
    }

    void SpawnTargets()
    {
        targetsRemaining = spawnPoints.Length;

        foreach (Transform point in spawnPoints)
        {
            GameObject target = Instantiate(targetPrefab, point.position, point.rotation);
            target.GetComponent<Target>().puzzleManager = this;
        }
    }

    IEnumerator ShowTargetsSequence()
    {
        playerInteract.enabled = false;

        playerController.EnableMovement(false);
        playerController.LockCamera(true);

        foreach (Camera cam in previewCameras)
        {
            if (cam == null) continue;

            cam.enabled = true;
            playerCamera.enabled = false;

            yield return new WaitForSeconds(previewTime);

            cam.enabled = false;
        }

        playerCamera.enabled = true;

        playerController.EnableMovement(true);
        playerController.LockCamera(false);

        playerInteract.enabled = true;
    }

    public void TargetDestroyed()
    {
        targetsRemaining--;

        if (targetsRemaining <= 0)
        {
            allTargetsDestroyed = true;

            if (playerOnCarpet)
            {
                StartLift();
            }
        }
    }

    public void SetPlayerOnCarpet(bool value)
    {
        playerOnCarpet = value;

        if (playerOnCarpet && allTargetsDestroyed && !lifting)
        {
            StartLift();
        }
    }

    void StartLift()
    {
        lifting = true;
    }

    void Update()
    {
        if (lifting)
        {
            Vector3 targetPos = new Vector3(carpet.position.x, liftHeight, carpet.position.z);
            carpet.position = Vector3.MoveTowards(carpet.position, targetPos, liftSpeed * Time.deltaTime);
        }
    }
}
