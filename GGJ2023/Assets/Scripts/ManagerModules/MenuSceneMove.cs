using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneMove : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
