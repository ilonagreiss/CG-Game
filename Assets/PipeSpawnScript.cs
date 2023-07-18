using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour {
    public GameObject pipe;
    public LogicScript logic;
    public float spawnRate = 1.5f;
    private float timer = 0;
    public float heightOffset = 7;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if(logic.gameActive) {
            SpawnPipe();
        }
    }

    void Update() {
        if(logic.gameActive) {
            if (timer < spawnRate) {
                timer += Time.deltaTime;
            } else {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    void SpawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
