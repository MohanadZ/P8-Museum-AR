using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryOptionsManager : MonoBehaviour
{
    public QuestionsText[] swordQuestions = null;
    [SerializeField] Button[] storyUIButtons = null;
    [SerializeField] Text[] storyButtonsText = null;

    ExhibitAudioManager exhibitAudioManager;

    private void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
    }

    public void ShowOptions(StoryPart[] exhibitStory)
    {
        FindObjectOfType<AudioControlManager>().HideAudioControlUI();

        if (exhibitStory[exhibitAudioManager.audioClipIndex].exhibitTag == "Sword")
        {
            DisplayStoryQuestionsUI(exhibitStory);
        }
    }

    private void DisplayStoryQuestionsUI(StoryPart[] exhibitStory)
    {
        if (exhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions == 3)
        {
            for (int i = 0; i < 3; i++)  // change number to a variable
            {
                storyUIButtons[i].gameObject.SetActive(true);
            }
            storyButtonsText[0].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[0].question;
            storyButtonsText[1].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[1].question;
            storyButtonsText[2].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[2].question;
        }
        else if (exhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions == 2)
        {
            if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[1].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[4].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[5].index)
            {
                for (int i = 3; i < 5; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[3].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[3].question;
                storyButtonsText[4].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[4].question;
            }
            else if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[2].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[6].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[7].index)
            {
                for (int i = 5; i < 7; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[5].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[5].question;
                storyButtonsText[6].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[6].question;
            }
            else if (exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[3].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[8].index || exhibitStory[exhibitAudioManager.audioClipIndex].index == exhibitAudioManager.currentExhibitStory[9].index)
            {
                for (int i = 7; i < 9; i++)  // change number to a variable
                {
                    storyUIButtons[i].gameObject.SetActive(true);
                }
                storyButtonsText[7].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[7].question;
                storyButtonsText[8].GetComponent<Text>().text = exhibitAudioManager.currentStoryQuestions[8].question;
            }
        }
    }

    public void ChooseStoryOption1()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[0].GetComponent<Image>().color = Color.gray;
        storyUIButtons[0].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[1].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption2()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[1].GetComponent<Image>().color = Color.gray;
        storyUIButtons[1].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[2].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption3()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[2].GetComponent<Image>().color = Color.gray;
        storyUIButtons[2].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[3].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);
    }

    public void ChooseStoryOption4()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[3].GetComponent<Image>().color = Color.gray;
        storyUIButtons[3].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[4].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[4].hasFinished && exhibitAudioManager.currentExhibitStory[5].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseStoryOption5()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[4].GetComponent<Image>().color = Color.gray;
        storyUIButtons[4].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[5].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[4].hasFinished && exhibitAudioManager.currentExhibitStory[5].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseStoryOption6()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[5].GetComponent<Image>().color = Color.gray;
        storyUIButtons[5].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[6].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[6].hasFinished && exhibitAudioManager.currentExhibitStory[7].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseStoryOption7()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[6].GetComponent<Image>().color = Color.gray;
        storyUIButtons[6].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[7].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[6].hasFinished && exhibitAudioManager.currentExhibitStory[7].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseStoryOption8()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[7].GetComponent<Image>().color = Color.gray;
        storyUIButtons[7].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[8].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[8].hasFinished && exhibitAudioManager.currentExhibitStory[9].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseStoryOption9()
    {
        for (int i = 0; i < storyUIButtons.Length; i++)
        {
            storyUIButtons[i].gameObject.SetActive(false);
        }
        storyUIButtons[8].GetComponent<Image>().color = Color.gray;
        storyUIButtons[8].interactable = false;

        exhibitAudioManager.audioClipIndex = exhibitAudioManager.currentExhibitStory[9].index;
        exhibitAudioManager.PlayAudio(exhibitAudioManager.currentExhibitStory, exhibitAudioManager.audioClipIndex);

        exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].hasFinished = true;

        if (exhibitAudioManager.currentExhibitStory[8].hasFinished && exhibitAudioManager.currentExhibitStory[9].hasFinished)
        {
            exhibitAudioManager.currentExhibitStory[exhibitAudioManager.audioClipIndex].numberOfOptions = 3;
        }
    }
}
