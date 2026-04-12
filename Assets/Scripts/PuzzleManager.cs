using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints;

    public int targetsRemaining;
    public bool playerOnCarpet = false;

    public Transform carpet;
    public float liftHeight = 10f;
    public float liftSpeed = 2f;

    private bool lifting = false;

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
            Startlift();
        }
    }

    void Startlift()
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
