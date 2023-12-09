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
        StartCoroutine(ShowPopUpAfterDelay(1f));
    }

    IEnumerator ShowPopUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Canvas canvas = FindObjectOfType<Canvas>();
        // Instantiate the pop-up prefab
        GameObject popUp = Instantiate(popUpPrefab, canvas.transform);

        // Set the pop-up as a child of the canvas
        popUp.transform.localPosition = Vector3.zero;
        popUp.transform.localRotation = Quaternion.identity;
    }
}
