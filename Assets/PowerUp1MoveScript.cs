using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1MoveScript : MonoBehaviour {
    public LogicScript logic;
    public float moveSpeed = 10;
    public float deadZone = -30;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Debug.Log("PowerUp1 Deleted");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 3) {
            logic.increaseScore(5);
        }
    }
}
