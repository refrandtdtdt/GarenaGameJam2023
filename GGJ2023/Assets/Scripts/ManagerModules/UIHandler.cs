using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, coinText, highscoreText;
    [SerializeField] private TextMeshProUGUI popupscoreText, popupcoinText, popuphighscoreText;
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
        coinText.text = "" + currency.getCoins();
        highscoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore");
        popupscoreText.text = "" + scoreKeeper.getScore();
        popupcoinText.text = "" + currency.getCoins();
        popuphighscoreText.text = "" + PlayerPrefs.GetInt("Highscore");
    }
}
