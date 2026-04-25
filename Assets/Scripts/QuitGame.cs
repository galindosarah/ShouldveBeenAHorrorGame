// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// Annette Gonzalez
// This script allows the player to quit game pressing the "esc" key.

using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
    }
}
