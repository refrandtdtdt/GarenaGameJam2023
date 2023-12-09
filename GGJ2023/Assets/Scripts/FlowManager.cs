using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FlowManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    Currency currency;
    [SerializeField] GameObject newHighscoreText, gameOverPopup;

    private void Awake()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();
        currency = GetComponent<Currency>();
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

    public void gameOver()
    {
        saveRun();
        StartCoroutine(WaitPopup());
    }
    IEnumerator WaitPopup()
    {
        yield return new WaitForSeconds(3);
        gameOverPopup.SetActive(true);
    }
}
