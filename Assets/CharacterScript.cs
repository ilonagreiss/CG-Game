using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class CharacterScript : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public LogicScript logic;
    public AudioSource collisionSound;
    public AudioSource jumpSound;
    public SpriteRenderer spriteRenderer;
    public Color originalColor;
    public bool charIsAlive = true;
    public bool isGhost = false;

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

            if(isGhost) {
                Color ghostColor = originalColor;
                ghostColor.a = 0.5f; // Set the alpha value to a semi-transparent value (0 = fully transparent, 1 = fully opaque) to make sprite look like a ghost
                spriteRenderer.color = ghostColor;
            } else {
                spriteRenderer.color = originalColor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(logic.gameActive) {
            charIsAlive = false;
            collisionSound.Play();
            gameOver();
        }
    }

    public async void ActivateGhostMode() {
        GetComponent<Collider2D>().isTrigger = true;
        isGhost = true;
        await WaitAsync();
        GetComponent<Collider2D>().isTrigger = false;
        isGhost = false;
    }

    private async Task WaitAsync() {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }

    private void gameOver() {
        logic.gameOver();
    }
}
