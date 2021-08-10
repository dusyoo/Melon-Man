using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour {
    private int melonCount = 0;
    [SerializeField] private Text melonCountText;

    private void OnTriggerEnter2D(Collider2D collision) {
        // If a collision occurs with a melon, update melon counter and display on screen
        if (collision.gameObject.CompareTag("Melon")) {
            Destroy(collision.gameObject);
             melonCount++;
             melonCountText.text = "Melons: " + melonCount;
        }
    }
}
