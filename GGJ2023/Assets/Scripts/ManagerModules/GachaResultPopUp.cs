using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaResultPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpPrefab;

    void Start()
    {
        // Subscribe to the event triggered by the ChestController script
        ChestController.OnChestOpened += ShowGachaResultPopUp;
    }

    void ShowGachaResultPopUp()
    {
        // Wait for 3 seconds before showing the pop-up
        StartCoroutine(ShowPopUpAfterDelay(3f));
    }

    IEnumerator ShowPopUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Instantiate the pop-up prefab
        GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);

        // Set the pop-up as a child of the canvas
        popUp.transform.SetParent(transform, false);
    }
}
