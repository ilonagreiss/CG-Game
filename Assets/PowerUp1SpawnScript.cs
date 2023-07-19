using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1SpawnScript : MonoBehaviour {
    public LogicScript logic;
    public GameObject powerUp1;
    public float spawnRate = 10;
    private float timer = 0;
    public float heightOffset = 10;
    private PipeSpawnScript pipeSpawnScript;

    void Start() {
        pipeSpawnScript = FindObjectOfType<PipeSpawnScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if(pipeSpawnScript == null) {
            Debug.LogError("PowerUpSpawnScript requires a reference to PipeSpawnScript.");
        }
    }

    void Update() {
        if(logic.gameActive) {
            if (timer < spawnRate) {
                timer += Time.deltaTime;
            } else {
                SpawnPowerUp();
                timer = 0;
            }
        }
    }

    void SpawnPowerUp() {
        if (pipeSpawnScript == null) {
            Debug.LogError("PowerUpSpawnScript requires a reference to PipeSpawnScript.");
            return;
        }

        float lowestPoint = pipeSpawnScript.transform.position.y - heightOffset;
        float highestPoint = pipeSpawnScript.transform.position.y + heightOffset;

        Vector3 spawnPosition = new Vector3(pipeSpawnScript.transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        // Check if the spawn position overlaps with the pipe
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);
        bool isOverlapping = false;
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Pipe")) {
                isOverlapping = true;
                break;
            }
        }

        // Spawn power-up if not overlapping with a pipe
        if (!isOverlapping) {
            Instantiate(powerUp1, spawnPosition, transform.rotation);
        }
    }
}

