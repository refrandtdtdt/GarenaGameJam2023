using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FlowManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    Currency currency;
    [SerializeField] GameObject newHighscoreText, gameOverPopup, gameUI;
    [SerializeField] PlayerMove player;

    private void Awake()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();
        currency = GetComponent<Currency>();
        gameOverPopup.SetActive(false);
    }

    private void saveRun()
    {
        // save new highscores
        if (scoreKeeper.newHighscore())
        {
            newHighscoreText.SetActive(true);
            PlayerPrefs.SetInt("Highscore", scoreKeeper.getScore());
        }

        // calculate coin pickup
        currency.increaseCoins(scoreKeeper.getScore() / 10);
        currency.saveCoins();
    }

    public void retryRun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void gameOver()
    {
        player.StopPlayer();
        gameUI.SetActive(false);
        saveRun();
        StartCoroutine(WaitPopup());
    }
    IEnumerator WaitPopup()
    {
        yield return new WaitForSeconds(2);
        gameOverPopup.SetActive(true);
    }
}
