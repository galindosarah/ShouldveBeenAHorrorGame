using UnityEngine;
using DigitalWorlds;

public class PlayerCrouch : MonoBehaviour
{
    private CapsuleCollider col;

    public float crouchHeight = 1f;
    public float smoothSpeed = 10f;

    private float normalHeight;
    private Vector3 normalCenter;
    private Vector3 crouchCenter;


    public Transform cameraHolder;
    private Vector3 normalCamPos;
    public Vector3 crouchCamPos;

    public GameObject playerModel;

    private bool wasCrouching = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<CapsuleCollider>();

        normalHeight = col.height;
        normalCenter = col.center;

        crouchCenter = new Vector3(normalCenter.x, crouchHeight / 2f, normalCenter.z);

        if (cameraHolder != null)
        {
            normalCamPos = cameraHolder.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
         bool isCrouching = Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl);
        
        float targetHeight = isCrouching ? crouchHeight : normalHeight;
        col.height = Mathf.Lerp(col.height, targetHeight, Time.deltaTime * smoothSpeed);

        Vector3 targetCenter = isCrouching ? crouchCenter : normalCenter;
        col.center = Vector3.Lerp(col.center, targetCenter, Time.deltaTime * smoothSpeed);

        if (cameraHolder != null)
        {
            Vector3 targetCamPos = isCrouching ? crouchCamPos : normalCamPos;
            cameraHolder.localPosition = Vector3.Lerp(cameraHolder.localPosition, targetCamPos, Time.deltaTime * smoothSpeed);
        }

        if (playerModel != null && isCrouching != wasCrouching)
        {
            playerModel.SetActive(!isCrouching);
            wasCrouching = isCrouching;
        }
    }
}
