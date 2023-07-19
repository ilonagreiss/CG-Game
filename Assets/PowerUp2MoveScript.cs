using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2MoveScript : MonoBehaviour  {
    public CharacterScript character;
    public LogicScript logic;
    public AudioSource triggerSound;
    public float moveSpeed = 10;
    public float deadZone = -30;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        character = GameObject.FindWithTag("Player").GetComponent<CharacterScript>();
    }

    void Update() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3 && logic.gameActive) {
            triggerSound.Play();
            character.ActivateGhostMode();
        }
    }
}
