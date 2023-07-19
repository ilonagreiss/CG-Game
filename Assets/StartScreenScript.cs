using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class StartScreenScript : MonoBehaviour {
    public AudioSource buttonClickSound;

    public async void onClickStartGame() {
        buttonClickSound.Play();
        await WaitAsync(0.1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private async Task WaitAsync(double seconds) {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }
}
