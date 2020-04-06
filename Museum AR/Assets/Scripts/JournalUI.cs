using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    [SerializeField] Image inputBlocker = null;
    [SerializeField] Image journalImage = null;
    [SerializeField] Image background = null;
    [SerializeField] Sprite journalIcon = null;
    [SerializeField] Sprite closeIcon = null;
    [SerializeField] Image[] exhibitImages = null;

    Animator animator = null;

    private bool closeIconIsShowing = false;

    public static event Action JournalUIClosedEvent;
    public static event Action<ExhibitTag> ExhibitVisitedEvent;

    private void Awake()
    {
        journalImage.GetComponent<Image>();
        background.GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    public void ExpandJournalUI()
    {
        inputBlocker.gameObject.SetActive(true);
        animator.SetTrigger("expandUI");

        if (closeIconIsShowing)
        {
            JournalUIClosedEvent();
        }
    }
    
    //Animation event
    public void SwitchSprite()
    {
        if (!closeIconIsShowing)
        {
            journalImage.sprite = closeIcon;
        }
        else
        {
            journalImage.sprite = journalIcon;
        }

        closeIconIsShowing = !closeIconIsShowing;
    }

    //Animation event
    public void EnableExhibitButtons()
    {
        for (int i = 0; i < exhibitImages.Length; i++)
        {
            exhibitImages[i].gameObject.SetActive(true);
        }

        animator.SetBool("enableButtons", true);
    }

    //Animation event
    public void DisableExhibitButtons()
    {
        animator.SetBool("enableButtons", false);

        for (int i = 0; i < exhibitImages.Length; i++)
        {
            exhibitImages[i].gameObject.SetActive(false);
        }

        animator.SetTrigger("shrinkBackground");
    }

    //Animation event
    public void EnableInput()
    {
        inputBlocker.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ExhibitVisitedEvent(ExhibitTag.Petrea);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ExhibitVisitedEvent(ExhibitTag.Bank);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ExhibitVisitedEvent(ExhibitTag.Bathtub);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ExhibitVisitedEvent(ExhibitTag.Sword);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ExhibitVisitedEvent(ExhibitTag.Tattoo);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ExhibitVisitedEvent(ExhibitTag.Skull);
        }
    }
}
