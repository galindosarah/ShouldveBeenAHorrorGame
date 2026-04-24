using UnityEngine;

public class ColorCandle : MonoBehaviour
{
    public ParticleSystem flameParticle;
    public Renderer wickRenderer;
    public ParticleSystem smokeParticle;

    public Color[] flameColors;
    public int currentColorIndex = -1;
    public int targetColorIndex;

    public CandlePuzzleManager puzzleManager;

    private Material wickMaterial;

    public AudioSource candleCrackle;

    [SerializeField] private Light candleLight;
    [SerializeField] private float normalBrightness = 0.1f;
    [SerializeField] private float correctBrightness = 5f;
    
    [SerializeField] private float normalRange = 0.5f;
    [SerializeField] private float correctRange = 2f;

    [SerializeField] private Transform flameTransform;
    [SerializeField] private Vector3 normalFlameScale = Vector3.one;
    [SerializeField] private Vector3 correctFlameScale = new Vector3(2.5f, 2.5f, 2.5f);

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
        ChangeMaterialColor(wickMaterial, newColor);
        TurnOnSmoke();
        TurnOnAudio();
        UpdateLight(newColor);
    }

    private void ChangeParticleColor(Color newColor)
    {
        if (flameParticle == null) return;

        var main = flameParticle.main;
        main.startColor = new ParticleSystem.MinMaxGradient(newColor);

        flameParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        flameParticle.Clear();
        flameParticle.Play();
    }

    private void ChangeMaterialColor(Material mat, Color newColor)
    {
        if (mat == null) return;

        if (mat.HasProperty("_TipColor"))
            mat.SetColor("_TipColor", newColor);
    }

    private void TurnOnSmoke()
    {
        if (smokeParticle == null) return;

        if (!smokeParticle.isPlaying)
        {
            smokeParticle.Play();
        }
    }

    private void TurnOnAudio()
    {
        if (candleCrackle == null) return;

        if (!candleCrackle.isPlaying)
        {
            candleCrackle.Play();
        }
    }

    private void UpdateLight(Color newColor)
    {
        if (candleLight == null) return;

        candleLight.enabled = true;
        candleLight.color = newColor;

        if (currentColorIndex == targetColorIndex)
        {
            candleLight.intensity = correctBrightness;
            candleLight.range = correctRange;
            if (flameTransform != null)
            {
                flameTransform.localScale = correctFlameScale;
            }

        }
        else
        {
            candleLight.intensity = normalBrightness;
            candleLight.range = normalRange;
            if (flameTransform != null)
            {
                flameTransform.localScale = normalFlameScale;
            }
        }
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

        if (candleCrackle != null)
        {
            candleCrackle.Stop();
        }

        if (candleLight != null)
        {
            candleLight.enabled = false;
            candleLight.intensity = 0f;
        }
    }
    public bool IsCorrectColor()
    {
        return currentColorIndex == targetColorIndex;
    }

}