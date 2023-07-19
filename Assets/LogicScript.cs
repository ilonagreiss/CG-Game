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
    public AudioSource buttonClickSound;
    public GameObject gameOverScreen;

    void Start() {
        playerScore = 0;
        gameActive = true;
    }

    public void increaseScore(int num) {
        playerScore += num;
        currentScoreText.text = playerScore.ToString();
    }

    public async void onClickTryAgain() {
        buttonClickSound.Play();
        await WaitAsync(0.1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public async void gameOver() {
        gameActive = false;
        gameOverSound.Play();
        await WaitAsync(1);
        gameOverScreen.SetActive(true);
    }

    private async Task WaitAsync(double seconds) {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }

    public async void onClickQuit() {
        buttonClickSound.Play();
        await WaitAsync(0.1);
        Application.Quit();
    }
}
