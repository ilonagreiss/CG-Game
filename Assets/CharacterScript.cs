using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public LogicScript logic;
    public AudioSource collisionSound;
    public AudioSource jumpSound;
    public bool charIsAlive = true;
    public SpriteRenderer spriteRenderer;
    public Color originalColor;

    void Start() {
        originalColor = spriteRenderer.color;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update() {
        if(logic.gameActive) {
            if(Input.GetKeyDown(KeyCode.Space)  && charIsAlive == true) {
                rigidBody.velocity = Vector2.up * 7;
                jumpSound.Play();
            }
            
            if(transform.position.y > 16 || transform.position.y < -16) {
                gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(logic.gameActive) {
            collisionSound.Play();
            gameOver();
            charIsAlive = false;
        }
    }

    public void TogglePipeCollision(bool enableCollision) {
        // Enable or disable the characters's collider with the pipes
        GetComponent<Collider2D>().enabled = enableCollision;
    }

    public void SetGhostMode(bool isGhost) {
        if (isGhost)
        {
            // Adjust the transparency of the sprite to make it look like a ghost
            Color ghostColor = originalColor;
            ghostColor.a = 0.5f; // Set the alpha value to a semi-transparent value (0 = fully transparent, 1 = fully opaque)
            spriteRenderer.color = ghostColor;
        }
        else
        {
            // Reset the transparency of the sprite to normal
            spriteRenderer.color = originalColor;
        }
    }

    private void gameOver() {
        logic.gameOver();
    }
}
