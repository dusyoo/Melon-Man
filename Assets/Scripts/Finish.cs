using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            LevelCompleted();
        }
    }

    private void LevelCompleted() {
        // Load next scene in Unity build setting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
