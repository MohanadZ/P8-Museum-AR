using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExhibitButtonManager : MonoBehaviour
{
    [Header("Visited Journal Canvas References")]
    [SerializeField] Canvas visitedJournalCanvas = null;
    [SerializeField] TextMeshProUGUI visitedExhibitTitle = null;
    [SerializeField] Image visitedExhibitImage = null;
    [SerializeField] TextMeshProUGUI visitedExhibitText = null;

    [Header("Unvisited Journal Canvas References")]
    [SerializeField] Canvas unvisitedJournalCanvas = null;
    [SerializeField] TextMeshProUGUI unvisitedExhibitTitle = null;
    [SerializeField] Image unvisitedExhibitImage = null;

    ExhibitButton[] exhibitButtons = null;

    private void Awake()
    {
        visitedJournalCanvas.GetComponent<Canvas>();
        visitedExhibitTitle.GetComponent<TextMeshProUGUI>();
        visitedExhibitImage.GetComponent<Image>();
        visitedExhibitText.GetComponent<TextMeshProUGUI>();

        unvisitedJournalCanvas.GetComponent<Canvas>();
        unvisitedExhibitTitle.GetComponent<TextMeshProUGUI>();
        unvisitedExhibitImage.GetComponent<Image>();
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
            ShowVisitedJournal(exhibitButton);
        }
        else
        {
            ShowUnvisitedJournal(exhibitButton);
        }
    }

    private void ShowVisitedJournal(ExhibitButton exhibitButton)
    {
        visitedExhibitTitle.text = exhibitButton.Title;
        visitedExhibitImage.sprite = exhibitButton.ExhibitImage;
        visitedExhibitText.text = exhibitButton.ExhibitText;

        if (!visitedJournalCanvas.gameObject.activeSelf)
        {
            unvisitedJournalCanvas.gameObject.SetActive(false);
            visitedJournalCanvas.gameObject.SetActive(true);
        }
    }

    private void ShowUnvisitedJournal(ExhibitButton exhibitButton)
    {
        unvisitedExhibitTitle.text = exhibitButton.Title;
        unvisitedExhibitImage.sprite = exhibitButton.ExhibitImage;

        if (!unvisitedJournalCanvas.gameObject.activeSelf)
        {
            visitedJournalCanvas.gameObject.SetActive(false);
            unvisitedJournalCanvas.gameObject.SetActive(true);
        }
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

    private void OnJournalClosed()
    {
        visitedJournalCanvas.gameObject.SetActive(false);
        unvisitedJournalCanvas.gameObject.SetActive(false);
    }
}
