using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
// Manages all the params and sending triggers for the animator
public class PlayerAnimation : MonoBehaviour {
    public Animator animator;
    public Player player;

    // Parameters
    public bool sprinting, isTouchingGround, falling, sliding;
    public float velX, velY;

    // Trigger names
    public static string JUMPED = "Jumped",
    ROLLED = "Rolled",
    LANDED = "Landed";

    void Start() {
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        // Flip character based on velocity / input
        transform.localScale = new Vector2(player.movement.facing, transform.localScale.y);

        animator.SetBool("sprinting", sprinting);
        animator.SetBool("isTouchingGround", isTouchingGround);
        animator.SetBool("falling", falling);
        animator.SetBool("sliding", sliding);
        animator.SetBool("jumpHeld", player.controls.jumpHeld);
        animator.SetFloat("velY", velY);
        animator.SetFloat("velX", velX);
        animator.SetFloat("inX", player.controls.XInput);
        animator.SetFloat("inY", player.controls.YInput);
    }

    public void SetTrigger(string triggerName) {
        animator.SetTrigger(triggerName);
    }
}
