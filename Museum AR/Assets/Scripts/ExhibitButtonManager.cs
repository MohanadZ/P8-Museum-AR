using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExhibitButtonManager : MonoBehaviour
{
    [Header("Visited Journal Canvas References")]
    [SerializeField] Canvas journalCanvas = null;
    [SerializeField] TextMeshProUGUI exhibitTitle = null;
    [SerializeField] Image exhibitImage = null;
    [SerializeField] TextMeshProUGUI exhibitText = null;

    ExhibitButton[] exhibitButtons = null;
    string defaultExhibitText = "";

    private void Awake()
    {
        journalCanvas.GetComponent<Canvas>();
        exhibitTitle.GetComponent<TextMeshProUGUI>();
        exhibitImage.GetComponent<Image>();
        exhibitText.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StoryCompletionManager.ExhibitVisitedEvent += OnExhibitVisited;
        JournalUI.ExhibitVisitedEvent += OnExhibitVisited;      // for testing
        JournalUI.JournalUIClosedEvent += OnJournalClosed;
        //Subscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void OnDisable()
    {
        StoryCompletionManager.ExhibitVisitedEvent -= OnExhibitVisited;
        JournalUI.ExhibitVisitedEvent -= OnExhibitVisited;      // for testing
        JournalUI.JournalUIClosedEvent -= OnJournalClosed;
        //Unsubscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void Start()
    {
        defaultExhibitText = exhibitText.text;
        exhibitButtons = FindObjectsOfType<ExhibitButton>();

        for (int i = 0; i < exhibitButtons.Length; i++)
        {
            exhibitButtons[i].gameObject.SetActive(false);
        }
    }

    public void OpenJournal(ExhibitButton exhibitButton)
    {
        exhibitTitle.text = exhibitButton.Title;
        exhibitImage.sprite = exhibitButton.ExhibitImage;

        if (exhibitButton.gameObject.tag == "Visited")
        {
            exhibitText.text = exhibitButton.ExhibitText;
        }
        else
        {
            exhibitText.text = defaultExhibitText;
        }

        journalCanvas.gameObject.SetActive(true);
    }

    private void OnExhibitVisited(ExhibitTag exhibitTag)
    {
        for(int i = 0; i < exhibitButtons.Length; i++)
        {
            ExhibitButton exhibitButton = exhibitButtons[i];

            if(exhibitButton.ExhibitTag == exhibitTag)
            {
                Image iconImage = exhibitButton.transform.GetChild(0).GetComponent<Image>();
                Color temporaryColor = iconImage.color;
                temporaryColor.a = 1f;
                iconImage.color = temporaryColor;
                exhibitButton.gameObject.tag = "Visited";
            }
        }
    }

    public void OnJournalClosed()
    {
        journalCanvas.gameObject.SetActive(false);
    }
}
