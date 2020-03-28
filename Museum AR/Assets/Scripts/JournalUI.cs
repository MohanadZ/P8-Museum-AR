using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    [SerializeField] Image journalImage = null;
    [SerializeField] Image background = null;
    [SerializeField] Sprite journalIcon = null;
    [SerializeField] Sprite closeIcon = null;
    [SerializeField] Image[] exhibitImages = null;

    private bool closeIconIsShowing = false;

    public static event Action JournalUIClosedEvent;

    private void Awake()
    {
        journalImage.GetComponent<Image>();
        background.GetComponent<Image>();
    }

    public void ExpandJournalUI()
    {
        if (!closeIconIsShowing)
        {
            journalImage.sprite = closeIcon;
            background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 600f);

            for(int i = 0; i < exhibitImages.Length; i++)
            {
                exhibitImages[i].gameObject.SetActive(true);
            }
        }
        else
        {
            journalImage.sprite = journalIcon;
            background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75f);

            for (int i = 0; i < exhibitImages.Length; i++)
            {
                exhibitImages[i].gameObject.SetActive(false);
            }

            JournalUIClosedEvent();
        }

        closeIconIsShowing = !closeIconIsShowing;
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

    public static event Action<ExhibitTag> ExhibitVisitedEvent;

}
