using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class PowerUp2MoveScript : MonoBehaviour  {
    public LogicScript logic;
    public float moveSpeed = 10;
    public float deadZone = -30;
    float ghostDuration = 3.5f;
    CharacterScript characterScript;

    void Start() {
        characterScript = GameObject.FindWithTag("Player").GetComponent<CharacterScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Debug.Log("PowerUp2 Deleted");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3) {
            ActivateGhostPowerup();
        }
    }

    async void ActivateGhostPowerup() {
        // Disable collision with pipes
        characterScript.TogglePipeCollision(false);

        // Set the characters's transparency or change its sprite to a ghost-like appearance
        characterScript.SetGhostMode(true);

        logic.increaseScore(5);

        await WaitAsync();

        DeactivateGhostPowerup();
    }

    void DeactivateGhostPowerup() {
        // Re-enable collision with pipes
        characterScript.TogglePipeCollision(true);

        // Disable the ghost mode
        characterScript.SetGhostMode(false);
    }

    private async Task WaitAsync() {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}
