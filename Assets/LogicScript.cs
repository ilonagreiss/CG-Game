using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class LogicScript : MonoBehaviour {
    public int playerScore;
    public Text currentScoreText;
    public Text scoreText;
    public bool gameActive = false;
    public AudioSource gameOverSound;
    public GameObject gameOverScreen;

    void Start() {
        playerScore = 0;
        gameActive = true;
    }

    public void increaseScore() {
        playerScore += 1;
        currentScoreText.text = playerScore.ToString();
    }

    public void onClickTryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public async void gameOver() {
        gameActive = false;
        gameOverSound.Play();
        await WaitAsync();
        gameOverScreen.SetActive(true);
    }

    private async Task WaitAsync() {
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    public void onClickQuit() {
        Application.Quit();
    }
}
