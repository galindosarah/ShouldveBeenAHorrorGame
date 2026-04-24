using UnityEngine;

public class ColorCandle : MonoBehaviour
{
    [Header("Candle Parts")]
    public ParticleSystem flameParticle;
    public Renderer wickRenderer;
    public ParticleSystem smokeParticle;


    [Header("Puzzle Colors")]
    public Color[] flameColors;
    public int currentColorIndex = -1;
    public int targetColorIndex;

    [Header("Puzzle Manager")]
    public CandlePuzzleManager puzzleManager;

    private Material wickMaterial;
    private Material flameMaterial;

    private void Start()
    {
        if (wickRenderer != null)
            wickMaterial = wickRenderer.material;

        TurnOffFlame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            Debug.Log("Fireball hit candle: " + gameObject.name);

            CycleColor();

            if (smokeParticle == null)
            {
                smokeParticle.Play();
            }
            

            if (puzzleManager != null)
                puzzleManager.CheckPuzzle();

            Destroy(other.gameObject);
        }
    }

    private void CycleColor()
    {
        if (flameColors == null || flameColors.Length == 0)
        {
            Debug.LogWarning("No flame colors assigned on " + gameObject.name);
            return;
        }

        currentColorIndex++;

        if (currentColorIndex >= flameColors.Length)
            currentColorIndex = 0;

        Color newColor = flameColors[currentColorIndex];

        Debug.Log(gameObject.name + " changed to color index: " + currentColorIndex);

        ChangeParticleColor(newColor);
        ChangeMaterialColor(flameMaterial, newColor);
        ChangeMaterialColor(wickMaterial, newColor);
    }

    private void ChangeParticleColor(Color newColor)
    {
        if (flameParticle == null) return;

        var main = flameParticle.main;

        main.startColor = new ParticleSystem.MinMaxGradient(newColor);

        flameParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        flameParticle.Clear();
        flameParticle.Play();

        TurnOnSmoke();

    }

    private void ChangeMaterialColor(Material mat, Color newColor)
    {
        if (mat == null) return;

        if (mat.HasProperty("_TipColor"))
            mat.SetColor("_TipColor", newColor);

    }

    private void TurnOffFlame()
    {
        if (flameParticle != null)
        {
            flameParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            flameParticle.Clear();
        }

        if (smokeParticle != null)
        {
            smokeParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            smokeParticle.Clear();
        }
    }

    private void TurnOnSmoke()
    {
        if (smokeParticle == null) return;

        if (!smokeParticle.isPlaying)
        {
            smokeParticle.Play();
        }
    }

    public bool IsCorrectColor()
    {
        return currentColorIndex == targetColorIndex;
    }
}