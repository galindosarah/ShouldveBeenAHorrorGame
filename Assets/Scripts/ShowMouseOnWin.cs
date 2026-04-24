using UnityEngine;

public class ShowMouseOnWinScreen : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}