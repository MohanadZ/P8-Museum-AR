using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exhibit : MonoBehaviour
{
    [SerializeField] StoryPart[] swordStory = null;
    [SerializeField] QuestionsText[] swordQuestions = null;
    [SerializeField] Button[] storyOptionsUI = null;
    [SerializeField] Text[] storyOptionsUIText = null;

    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public StoryPart[] currentExhibitStory = null;
    [HideInInspector] public int audioClipIndex = 0;
    [HideInInspector] public bool triggerSwordStory = false;
    [HideInInspector] public bool isDisplayQuestions = true;
    [HideInInspector] public IEnumerator coroutine;

    QuestionsText[] currentStoryQuestions = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ResetScriptableObjectsProperties();
    }

    private void ResetScriptableObjectsProperties()
    {
        foreach (StoryPart story in swordStory)
        {
            story.hasFinished = false;
        }

        for(int i = 4; i < swordStory.Length; i++)
        {
            swordStory[i].numberOfOptions = 2;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            triggerSwordStory = true;
        }

        if (triggerSwordStory)
        {
            //FindObjectOfType<AudioControlManager>().ShowAudioControlUI();
            currentExhibitStory = swordStory;
            currentStoryQuestions = swordQuestions;
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerSwordStory = false;
        }

        Debug.Log(isDisplayQuestions);
    }

    public void PlayAudio(StoryPart[] exhibitStory, int audioClipIndex)
    {
        if(audioClipIndex >= exhibitStory.Length) { return; }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(exhibitStory[audioClipIndex].audioClip);
            coroutine = WaitThenDisplayQuestions(exhibitStory);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitThenDisplayQuestions(StoryPart[] exhibitStory)
    {
        //yield return new WaitForSeconds(exhibitStory[audioClipIndex].audioClip.length);
        yield return new WaitUntil(() => !audioSource.isPlaying && isDisplayQuestions);
        ShowOptions(exhibitStory);
        //audioClipIndex++;
        //PlayAudio(exhibitStory, audioClipIndex);
    }

    public void ShowOptions(StoryPart[] exhibitStory)
    {
        FindObjectOfType<AudioControlManager>().HideAudioControlUI();

        if(exhibitStory[audioClipIndex].exhibitTag == "Sword")
        {
            DisplaySwordQuestionsUI(exhibitStory);
        }
        else
        {
            Debug.Log("It is of tag " + exhibitStory[audioClipIndex]);
        }
    }

    private void DisplaySwordQuestionsUI(StoryPart[] exhibitStory)
    {
        if (exhibitStory[audioClipIndex].numberOfOptions == 3)
        {
            for (int i = 0; i < 3; i++)  // change number to a variable
            {
                storyOptionsUI[i].gameObject.SetActive(true);
            }
            storyOptionsUIText[0].GetComponent<Text>().text = currentStoryQuestions[0].question;
            storyOptionsUIText[1].GetComponent<Text>().text = currentStoryQuestions[1].question;
            storyOptionsUIText[2].GetComponent<Text>().text = currentStoryQuestions[2].question;
        }
        else if (exhibitStory[audioClipIndex].numberOfOptions == 2)
        {
            if(exhibitStory[audioClipIndex].index == currentExhibitStory[1].index || exhibitStory[audioClipIndex].index == currentExhibitStory[4].index || exhibitStory[audioClipIndex].index == currentExhibitStory[5].index)
            {
                for (int i = 3; i < 5; i++)  // change number to a variable
                {
                    storyOptionsUI[i].gameObject.SetActive(true);
                }
                storyOptionsUIText[3].GetComponent<Text>().text = currentStoryQuestions[3].question;
                storyOptionsUIText[4].GetComponent<Text>().text = currentStoryQuestions[4].question;
            }
            else if (exhibitStory[audioClipIndex].index == currentExhibitStory[2].index || exhibitStory[audioClipIndex].index == currentExhibitStory[6].index || exhibitStory[audioClipIndex].index == currentExhibitStory[7].index)
            {
                for (int i = 5; i < 7; i++)  // change number to a variable
                {
                    storyOptionsUI[i].gameObject.SetActive(true);
                }
                storyOptionsUIText[5].GetComponent<Text>().text = currentStoryQuestions[5].question;
                storyOptionsUIText[6].GetComponent<Text>().text = currentStoryQuestions[6].question;
            }
            else if (exhibitStory[audioClipIndex].index == currentExhibitStory[3].index || exhibitStory[audioClipIndex].index == currentExhibitStory[8].index || exhibitStory[audioClipIndex].index == currentExhibitStory[9].index)
            {
                for (int i = 7; i < 9; i++)  // change number to a variable
                {
                    storyOptionsUI[i].gameObject.SetActive(true);
                }
                storyOptionsUIText[7].GetComponent<Text>().text = currentStoryQuestions[7].question;
                storyOptionsUIText[8].GetComponent<Text>().text = currentStoryQuestions[8].question;
            }
        }
    }

    public void ChooseSwordOption1()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[0].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[0].interactable = false;

        audioClipIndex = currentExhibitStory[1].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption2()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[1].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[1].interactable = false;

        audioClipIndex = currentExhibitStory[2].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption3()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[2].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[2].interactable = false;

        audioClipIndex = currentExhibitStory[3].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption4()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[3].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[3].interactable = false;

        audioClipIndex = currentExhibitStory[4].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if(currentExhibitStory[4].hasFinished && currentExhibitStory[5].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseSwordOption5()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[4].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[4].interactable = false;

        audioClipIndex = currentExhibitStory[5].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if (currentExhibitStory[4].hasFinished && currentExhibitStory[5].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseSwordOption6()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[5].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[5].interactable = false;

        audioClipIndex = currentExhibitStory[6].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if(currentExhibitStory[6].hasFinished && currentExhibitStory[7].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseSwordOption7()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[6].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[6].interactable = false;

        audioClipIndex = currentExhibitStory[7].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if (currentExhibitStory[6].hasFinished && currentExhibitStory[7].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseSwordOption8()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[7].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[7].interactable = false;

        audioClipIndex = currentExhibitStory[8].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if (currentExhibitStory[8].hasFinished && currentExhibitStory[9].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }

    public void ChooseSwordOption9()
    {
        for (int i = 0; i < storyOptionsUI.Length; i++)
        {
            storyOptionsUI[i].gameObject.SetActive(false);
        }
        storyOptionsUI[8].GetComponent<Image>().color = Color.gray;
        storyOptionsUI[8].interactable = false;

        audioClipIndex = currentExhibitStory[9].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if (currentExhibitStory[8].hasFinished && currentExhibitStory[9].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }
}