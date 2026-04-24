using System.Collections;
using System.Collections.Generic;
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

    public RigidbodyFPSController playerController;
    public PlayerInteract playerInteract;

    private bool lifting = false;
    private bool lowering = false;
    private bool allTargetsDestroyed = false;
    private bool started = false;

    private Vector3 carpetStartPos;
    private Vector3 carpetTopPos;

    public List<RotateObject> statues;

    [SerializeField] private GameObject itemToSpawn;
    [SerializeField] private Transform itemSpawnPoint;
    public bool statuePuzzleCompleted { get; private set; } = false;

    public AudioSource audioSource;
    public AudioClip spawnSound;
    public AudioClip targetSound;

    void Start()
    {
        carpetStartPos = carpet.position;
        carpetTopPos = new Vector3(carpetStartPos.x, liftHeight, carpetStartPos.z);

        foreach (Camera cam in previewCameras)
        {
            if (cam != null)
            {
                cam.enabled = false;
            }
        }
    }

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
        audioSource.PlayOneShot(targetSound);
        targetsRemaining--;

        if (targetsRemaining <= 0)
        {
            allTargetsDestroyed = true;

            if (playerOnCarpet && !lifting)
            {
                StartLift();
            }
        }
    }

    public void SetPlayerOnCarpet(bool value)
    {
        playerOnCarpet = value;

        if (playerOnCarpet && allTargetsDestroyed && !lifting && !lowering)
        {
            StartLift();
        }
        else if (!playerOnCarpet && lifting)
        {
            StartLower();
        }
    }

    void StartLift()
    {
        lowering = false;
        lifting = true;
    }

    void StartLower()
    {
        lifting = false;
        lowering = true;
    }

    void Update()
    {
        if (lifting)
        {
            carpet.position = Vector3.MoveTowards(carpet.position, carpetTopPos, liftSpeed * Time.deltaTime);

            if (Vector3.Distance(carpet.position, carpetTopPos) < 0.01f)
            {
                carpet.position = carpetTopPos;
                lifting = false;
            }
        }
        else if (lowering)
        {
            carpet.position = Vector3.MoveTowards(carpet.position, carpetStartPos, liftSpeed * Time.deltaTime);

            if (Vector3.Distance(carpet.position, carpetStartPos) < 0.01f)
            {
                carpet.position = carpetStartPos;
                lowering = false;
            }
        }
    }

    public void CheckStatuePuzzle()
    {   
        if (statuePuzzleCompleted)
        {
            return;
        }

        foreach (RotateObject statue in statues)
        {
            if (!statue.IsAligned())
            {
                return;
            }
        }

        statuePuzzleCompleted = true;
        Instantiate(itemToSpawn, itemSpawnPoint.position, itemSpawnPoint.rotation);
        audioSource.PlayOneShot(spawnSound);
    }
}