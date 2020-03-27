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
    [SerializeField] Canvas journalCanvas = null;
    [SerializeField] Image[] exhibitImages = null;

    private bool closeIconIsShowing = false;

    private void Awake()
    {
        journalImage.GetComponent<Image>();
        background.GetComponent<Image>();
        journalCanvas.GetComponent<Canvas>();
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
        }

        closeIconIsShowing = !closeIconIsShowing;
    }

    public void OpenJournal(Button button)
    {
        if(button.gameObject.tag == "Visited")
        {
            
            print("SHOWING SCROLL WITH TEXT FOR VISITED EXHIBIT");
        }
        else
        {
            print("SHOWING SCROLL WITH IMAGE FOR UNVISITED EXHIBIT");
        }
    }
}
