using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Transform player;
    private int highScore = 0;
    public int currScore = 0;
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
        currScore = Mathf.FloorToInt(currentPos - initialPos);
    }

    public bool newHighscore() { return currScore > highScore || !PlayerPrefs.HasKey("Highscore"); }

    public int getScore() { return currScore; }
}
