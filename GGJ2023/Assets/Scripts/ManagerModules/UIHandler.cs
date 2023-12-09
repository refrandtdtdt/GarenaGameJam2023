using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, coinText, highscoreText;
    [SerializeField] private TextMeshProUGUI popupscoreText, popuphighscoreText, scorecoinText, collectedcoinText, totalcoinText;
    private ScoreKeeper scoreKeeper;
    private Currency currency;

    void Start()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();
        currency = GetComponent<Currency>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + scoreKeeper.getScore();
        coinText.text = "" + currency.getRunCoins();
        highscoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore");
        popupscoreText.text = "" + scoreKeeper.getScore();
        popuphighscoreText.text = "" + PlayerPrefs.GetInt("Highscore");
        scorecoinText.text = "" + Mathf.FloorToInt(scoreKeeper.getScore()/10);
        collectedcoinText.text = "" + currency.getRunCoins();
        totalcoinText.text = "" + (Mathf.FloorToInt(scoreKeeper.getScore()/10) + currency.getRunCoins());
    }
}
