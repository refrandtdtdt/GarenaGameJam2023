using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaResultPopUp : MonoBehaviour
{
    public GameObject popUp;
    public TextMeshProUGUI popUpText;
    public Currency currency;
    public MenuScene menuscene;

    void Start()
    {
        // Subscribe to the event triggered by the ChestController script
        ChestController.OnChestOpened += ShowGachaResultPopUp;
    }

    public void ShowGachaResultPopUp()
    {
        // Wait for 1 second before showing the pop-up
        StartCoroutine(ShowPopUpAfterDelay(1f));
    }

    IEnumerator ShowPopUpAfterDelay(float delay)
    {
        string item = SavedItems.randomAdd();
        yield return new WaitForSeconds(delay);
        popUpText.text = item;
        if(item == "100 coins")
        {
            currency.increaseCoins(100);
        }
        if (item == "1000 coins")
        {
            currency.increaseCoins(1000);
        }
        menuscene.updateCoinText();
        popUp.SetActive(true);

        //Canvas canvas = FindObjectOfType<Canvas>();
        // Instantiate the pop-up prefab
        //GameObject popUp = Instantiate(popUpPrefab, canvas.transform);

        // Set the pop-up as a child of the canvas
        //popUp.transform.localPosition = Vector3.zero;
        //popUp.transform.localRotation = Quaternion.identity;
    }
}
