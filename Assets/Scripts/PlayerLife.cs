using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    private Animator anim;
    private PlayerMovement player;
    private void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // If player collides with a trap, call the Death method 
        if (collision.gameObject.CompareTag("Trap")) {
            Death();
            
        }
    }
     
    private void Death() {
        // Trigger death animation
        anim.SetTrigger("death");
        player.enabled = false;
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
