using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class LogicScript : MonoBehaviour {
    public int playerScore;
    public Text scoreText;
    public bool gameActive = false;

    void Start() {
        startNewGame();
    }

    public void startNewGame() {
        playerScore = 0;
        gameActive = true;
    }

    public void increaseScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    public async void gameOver() {
        gameActive = false;
        await WaitOneSecondAsync();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private async Task WaitOneSecondAsync() {
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
