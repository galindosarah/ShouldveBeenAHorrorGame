using UnityEngine;

public class CandlePuzzleManager : MonoBehaviour
{
    public ColorCandle[] candles;

    public GameObject specialGem;
    public Transform gemSpawnPoint;

    public AudioSource audioSource;
    public AudioClip spawnSound;

    private bool gemSpawned = false;

    public void CheckPuzzle()
    {
        if (gemSpawned) return;

        foreach (ColorCandle candle in candles)
        {
            if (!candle.IsCorrectColor())
            {
                return;
            }
        }

        SpawnGem();
    }

    private void SpawnGem()
    {
        gemSpawned = true;

        if (specialGem != null && gemSpawnPoint != null)
        {
            Instantiate(specialGem, gemSpawnPoint.position, gemSpawnPoint.rotation);
            audioSource.PlayOneShot(spawnSound);
        }
    }
}