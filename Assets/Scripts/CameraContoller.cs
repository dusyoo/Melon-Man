using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Independant camera controller to prevent following player's exact x, y and z coordinates
// i.e. if player's z coordinates somehow change, camera's z coordinates will shift as well
public class CameraContoller : MonoBehaviour {
    [SerializeField] private Transform player;
    // Update is called once per frame
    private void Update() {
        // Transform handles Transform component to position the camera's x, y and z coordinates
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
