using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScene : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, shopMenu, settingsMenu, howtoplayMenu, gachaMenu, creditsMenu, notification, notifText, coinText;
    [SerializeField] Slider volumeSlider;
    AudioSource audioSource;
    Currency currency;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
        currency = GetComponent<Currency>();
        updateCoinText();
    }
    public void play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void shop()
    {
        mainMenu.SetActive(false);
        currency.updateCoins();
        updateCoinText();
        shopMenu.SetActive(true);
    }

    public void ShopToMain()
    {
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void gacha()
    {
        if (currency.isEnough(500))
        {
            shopMenu.SetActive(false);
            gachaMenu.SetActive(true);
            currency.decreaseCoins(500);
            currency.saveCoins();
            updateCoinText();
        }
        else
        {
            StartCoroutine(showNotification("Not enough coins"));
        }
    }

    public void settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void howtoplay()
    {
        mainMenu.SetActive(false);
        howtoplayMenu.SetActive(true);
    }

    public void credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
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
        creditsMenu.SetActive(false);
        gachaMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void setVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void updateCoinText()
    {
        coinText.GetComponent<TextMeshProUGUI>().text = ""+currency.getCoins();
    }

    IEnumerator showNotification(string Text)
    {
        notifText.GetComponent<TextMeshProUGUI>().text = Text;
        notification.SetActive(true);
        yield return new WaitForSeconds(3);
        notification.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currency.increaseCoins(500);
            updateCoinText();
        }
    }
}
