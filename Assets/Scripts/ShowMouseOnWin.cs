// Final
// DIG 3878
// Celine Hui
// This script shows the cursor.

using UnityEngine;

public class ShowMouseOnWinScreen : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}