using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("ded");
            //SceneManager.LoadScene("Game Over");          nanti diganti pake nampilin popup beserta skor
        }
    }
}
