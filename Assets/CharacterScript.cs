using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public LogicScript logic;
    public AudioSource collisionSound;
    public AudioSource jumpSound;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update() {
        if(logic.gameActive) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                rigidBody.velocity = Vector2.up * 10;
                jumpSound.Play();
            }
            
            if(transform.position.y > 16 || transform.position.y < -16) {
                gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collisionSound.Play();
        gameOver();
    }

    private void gameOver() {
        logic.gameOver();
    }
}
