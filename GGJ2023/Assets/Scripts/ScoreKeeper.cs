using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int highScore = 0;
    private int currScore = 0;
    private float initialPos, currentPos;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }

        if(player != null)
        {
            initialPos = player.transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = player.transform.position.x;
        currScore = Mathf.RoundToInt(currentPos - initialPos);
        UpdateScores();
    }

    void UpdateScores()
    {
        scoreText.text = "Score= " + currScore;
    }

    public void SaveScores()
    {
        if(currScore > highScore)
        {
            PlayerPrefs.SetInt("Highscore", currScore);
        }
    }
}
