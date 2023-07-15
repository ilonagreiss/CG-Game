using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTriggerScript : MonoBehaviour {
    public LogicScript logic;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3) {
            logic.increaseScore();
        }
    }
}
