// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script allows the scene to be changed. 

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void ChangeScene(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}