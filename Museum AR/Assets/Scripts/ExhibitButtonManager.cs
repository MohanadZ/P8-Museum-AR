using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExhibitButtonManager : MonoBehaviour
{
    [SerializeField] Canvas journalCanvas = null;
    [SerializeField] TextMeshProUGUI exhibitTitle = null;
    [SerializeField] Image exhibitImage = null;
    [SerializeField] TextMeshProUGUI exhibitText = null;

    [SerializeField] ExhibitButton[] exhibitButtons = null;

    private void Awake()
    {
        journalCanvas.GetComponent<Canvas>();
        exhibitTitle.GetComponent<TextMeshProUGUI>();
        exhibitImage.GetComponent<Image>();
        exhibitText.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        JournalUI.ExhibitVisitedEvent += OnExhibitVisited;
        JournalUI.JournalUIClosedEvent += OnJournalClosed;
        //Subscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void OnDisable()
    {
        //JournalUI.ExhibitVisitedEvent -= OnExhibitVisited;
        JournalUI.JournalUIClosedEvent -= OnJournalClosed;
        //Unsubscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void Start()
    {
        exhibitButtons = FindObjectsOfType<ExhibitButton>();

        for (int i = 0; i < exhibitButtons.Length; i++)
        {
            exhibitButtons[i].gameObject.SetActive(false);
        }
    }

    public void OpenJournal(ExhibitButton exhibitButton)
    {
        if (exhibitButton.gameObject.tag == "Visited")
        {
            PopulateJournal(exhibitButton);
            //exhibitText.text = exhibitButton.ExhibitText.text;
            exhibitText.text = "THIS HAS BEEN VISITED";
        }
        else
        {
            PopulateJournal(exhibitButton);
            exhibitText.text = "Besøg udstillingen for at fylde siden med information om denne.";
        }
    }

    private void PopulateJournal(ExhibitButton exhibitButton)
    {
        exhibitTitle.text = exhibitButton.Title;
        exhibitImage.sprite = exhibitButton.ExhibitImage;
        journalCanvas.gameObject.SetActive(true);
    }

    private void OnExhibitVisited(ExhibitTag exhibitTag)
    {
        for(int i = 0; i < exhibitButtons.Length; i++)
        {
            ExhibitButton exhibitButton = exhibitButtons[i];

            if(exhibitButton.ExhibitTag == exhibitTag)
            {
                Image exhibitImage = exhibitButton.GetComponent<Image>();
                Color temporaryColor = exhibitImage.color;
                temporaryColor.a = 1f;
                exhibitImage.color = temporaryColor;
                exhibitButton.gameObject.tag = "Visited";
            }
        }
    }

    private void OnJournalClosed()
    {
        journalCanvas.gameObject.SetActive(false);
    }
}
