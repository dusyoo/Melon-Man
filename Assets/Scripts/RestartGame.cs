using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    public void Restart() {
        // Load previous scene in Unity build setting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
