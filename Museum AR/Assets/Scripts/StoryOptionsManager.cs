using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryOptionsManager : MonoBehaviour
{
    [SerializeField] Button[] storyUIButtons = null;
    [SerializeField] TextMeshProUGUI[] storyButtonsText = null;

    ExhibitAudioManager exhibitAudioManager;
    StoryCompletionManager storyCompletion;

    private void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        storyCompletion = FindObjectOfType<StoryCompletionManager>();
    }

    public void ShowOptions(StoryPart[] exhibitStory)
    {
        FindObjectOfType<AudioControlManager>().HideAudioControlUI();

        DisplayStoryQuestionsUI(exhibitStory);
    }

    private void DisplayStoryQuestionsUI(StoryPart[] exhibitStory)
    {
        if (exhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions == 3)
        {
            for (int i = 0; i < 3; i++)  // change number to a variable
            {
                storyUIButtons[i].gameObject.SetActive(true);
            }
            storyButtonsText[0].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[0].question;
            storyButtonsText[1].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[1].question;
            storyButtonsText[2].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[2].question;
        }
        else if (exhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions == 2)
        {
            if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[1].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[4].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[5].index)
            {
                for (int i = 3; i < 5; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[3].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[3].question;
                storyButtonsText[4].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[4].question;
            }
            else if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[2].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[6].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[7].index)
            {
                for (int i = 5; i < 7; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[5].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[5].question;
                storyButtonsText[6].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[6].question;
            }
            else if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[3].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[8].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[9].index)
            {
                for (int i = 7; i < 9; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[7].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[7].question;
                storyButtonsText[8].GetComponent<TextMeshProUGUI>().text = exhibitAudioManager.currentStoryQuestions[8].question;
            }
        }

        storyCompletion.CheckExhibitCompletion();
    }

    public void DisableOptionsButtons()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
    }

    public void ResetOptionsButtons()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].GetComponent<Image>().color = Color.white;
            storyUIButtons[i].interactable = true;
        }
    }

    public void ChooseStoryOption1()
    {
        DisableOptionsButtons();

        storyUIButtons[0].GetComponent<Image>().color = Color.gray;
        storyUIButtons[0].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[1].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption2()
    {
        DisableOptionsButtons();

        storyUIButtons[1].GetComponent<Image>().color = Color.gray;
        storyUIButtons[1].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[2].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption3()
    {
        DisableOptionsButtons();

        storyUIButtons[2].GetComponent<Image>().color = Color.gray;
        storyUIButtons[2].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[3].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption4()
    {
        DisableOptionsButtons();

        storyUIButtons[3].GetComponent<Image>().color = Color.gray;
        storyUIButtons[3].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[4].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[4].hasFinished && exhibitAudioManager.currentExhibitStory[5].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[1].hasFinished = true;
        }
    }

    public void ChooseStoryOption5()
    {
        DisableOptionsButtons();

        storyUIButtons[4].GetComponent<Image>().color = Color.gray;
        storyUIButtons[4].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[5].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[4].hasFinished && exhibitAudioManager.currentExhibitStory[5].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[1].hasFinished = true;
        }
    }

    public void ChooseStoryOption6()
    {
        DisableOptionsButtons();

        storyUIButtons[5].GetComponent<Image>().color = Color.gray;
        storyUIButtons[5].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[6].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[6].hasFinished && exhibitAudioManager.currentExhibitStory[7].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[2].hasFinished = true;
        }
    }

    public void ChooseStoryOption7()
    {
        DisableOptionsButtons();

        storyUIButtons[6].GetComponent<Image>().color = Color.gray;
        storyUIButtons[6].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[7].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[6].hasFinished && exhibitAudioManager.currentExhibitStory[7].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[2].hasFinished = true;
        }
    }

    public void ChooseStoryOption8()
    {
        DisableOptionsButtons();

        storyUIButtons[7].GetComponent<Image>().color = Color.gray;
        storyUIButtons[7].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[8].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[8].hasFinished && exhibitAudioManager.currentExhibitStory[9].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[3].hasFinished = true;
        }
    }

    public void ChooseStoryOption9()
    {
        DisableOptionsButtons();

        storyUIButtons[8].GetComponent<Image>().color = Color.gray;
        storyUIButtons[8].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[9].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[8].hasFinished && exhibitAudioManager.currentExhibitStory[9].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
            exhibitAudioManager.currentExhibitStory[3].hasFinished = true;
        }
    }
}
