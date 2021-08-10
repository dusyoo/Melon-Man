using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Rigidbody physics component for 2D sprites.
    private Rigidbody2D rb;
    // Interface to control the Mecanim animation system.
    private Animator anim;
    // Collider for 2D physics representing an axis-aligned rectangle.
    private BoxCollider2D coll;
    // Renders a Sprite for 2D graphics.
    private SpriteRenderer spriteRend;
    [SerializeField] private LayerMask jumpableGround;

    // Player horizontal position
    private float dirX;
    // Player movement speed value
    private float moveSpeed = 10;
    // Player jump force value
    private float jumpForce = 15;

    private enum MovementState { IDLE, RUNNING, JUMPING, FALLING }

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update() {
        // Store player's movements
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateJump();
        UpdateAnimation();
    }

    private void UpdateJump() {
        // Implementing Unity's input manager
        if(Input.GetButtonDown("Jump") && isGrounded()) {
            // player jumps 14 units high
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void UpdateAnimation() {
        MovementState state;

        if (dirX > 0) {
            state = MovementState.RUNNING;
            spriteRend.flipX = false;
        } else if (dirX < 0) {
            state = MovementState.RUNNING;
            spriteRend.flipX = true;
        } else {
            state = MovementState.IDLE;
        }
        
        // Through testing animations, value of idle is never at exact 0
        if (rb.velocity.y > 1) {
            state = MovementState.JUMPING;
        } else if (rb.velocity.y < -1) {
            state = MovementState.FALLING;
        }

        anim.SetInteger("state", (int) state);
    }

    private bool isGrounded() {
        // BoxCast creates a box the same size as player's hitbox
        // Making the box 0.1 lower than player's hitbox to check if BoxCast is touching terrain
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
    }
}
