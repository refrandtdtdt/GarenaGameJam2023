using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, shopMenu, settingsMenu, howtoplayMenu, gachaMenu;
    [SerializeField] Slider volumeSlider;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }
    public void play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void shop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void ShopToMain()
    {
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void gacha()
    {
        shopMenu.SetActive(false);
        gachaMenu.SetActive(true);
    }

    public void settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void howtoplay()
    {
        mainMenu.SetActive(false);
        howtoplayMenu.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void backToMain()
    {
        shopMenu.SetActive(false);
        settingsMenu.SetActive(false);
        howtoplayMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void setVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
