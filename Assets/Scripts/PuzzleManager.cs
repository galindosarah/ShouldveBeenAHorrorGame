using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints;

    public int targetsRemaining;

    public Transform carpet;
    public float liftHeight = 10f;
    public float liftSpeed = 2f;

    private bool lifting = false;
    private Vector3 targetPosition;

    public void StartPuzzle()
    {
        SpawnTargets();
    }

    void SpawnTargets()
    {
        targetsRemaining = spawnPoints.Length;

        foreach (Transform point in spawnPoints)
        {
            GameObject target = Instantiate(targetPrefab, point.position, Quaternion.identity);
            target.GetComponent<Target>().puzzleManager = this;
        }
    }

    public void TargetDestroyed()
    {
        targetsRemaining--;

        if (targetsRemaining <= 0)
        {
            PuzzleComplete();
        }
    }

    void PuzzleComplete()
    {
        targetPosition = carpet.position + Vector3.up * liftHeight;
        lifting = true;
    }

    void Update()
    {
        if (lifting)
        {
            carpet.position = Vector3.MoveTowards(carpet.position, targetPosition, liftSpeed * Time.deltaTime);
        }
    }
}
