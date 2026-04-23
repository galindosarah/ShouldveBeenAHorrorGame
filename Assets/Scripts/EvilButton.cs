using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class EvilButton : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject jumpscareImage;
    [SerializeField] private float jumpscareDuration = 2f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraShakeMagnitude = 0.2f;
    [SerializeField] private float imageShakeMagnitude = 0.5f;
    private bool used = false;


    public void Interact(Transform player, Transform inspectPoint)
    {
        if (used) return;

        used = true;
        GameStateManager.Instance.SetState(GameState.Gameplay);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        StartCoroutine(Jumpscare());
    }

    public void StopInteract()
    {
    }

    public bool RequiresInspection()
    {
        return false;
    }

    private IEnumerator Jumpscare()
    {
        jumpscareImage.SetActive(true);
        StartCoroutine(ShakeCamera());
        StartCoroutine(ShakeImage());
        yield return new WaitForSeconds(jumpscareDuration);
        SceneManager.LoadScene(0);
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPos = cameraTransform.localPosition;

        float elapsed = 0f;

        while (elapsed < jumpscareDuration)
        {
            float x = Random.Range(-1f, 1f) * cameraShakeMagnitude;
            float y = Random.Range(-1f, 1f) * cameraShakeMagnitude;

            cameraTransform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }

    private IEnumerator ShakeImage()
    {   
        RectTransform rect = jumpscareImage.GetComponent<RectTransform>();
        Vector2 originalPos = rect.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < jumpscareDuration)
        {
            float x = Random.Range(-1f, 1f) * imageShakeMagnitude;
            float y = Random.Range(-1f, 1f) * imageShakeMagnitude;

            rect.anchoredPosition = originalPos + new Vector2(x, y);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rect.anchoredPosition = originalPos;
    }
}