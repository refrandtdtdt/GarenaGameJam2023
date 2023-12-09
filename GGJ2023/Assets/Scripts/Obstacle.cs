using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private FlowManager manager;
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FlowManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("ded");
            manager.gameOver();
            //SceneManager.LoadScene("Game Over");          nanti diganti pake nampilin popup beserta skor
        }
    }
}
