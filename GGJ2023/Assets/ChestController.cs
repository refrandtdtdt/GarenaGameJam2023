using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestController : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    private bool isOpened = false;

    public delegate void ChestOpenedAction();
    public static event ChestOpenedAction OnChestOpened;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        // Trigger the animation
        if (!isOpened)
        {
            // Trigger the "OpenChestTrigger" parameter
            animator.SetBool("isOpened", true);

            // Set the flag to true to prevent further opening
            isOpened = true;

            OnChestOpened?.Invoke();
        }
    }
}
