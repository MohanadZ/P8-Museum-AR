using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exhibit : MonoBehaviour
{
    [SerializeField] StoryPart[] swordStory = null;
    [SerializeField] QuestionsText[] swordQuestions = null;
    [SerializeField] Button[] swordOptionsUI = null;
    [SerializeField] Text[] swordOptionsUIText = null;
    [HideInInspector] public bool triggerSwordStory = false;
    AudioSource audioSource;
    StoryPart[] currentExhibitStory = null;
    int audioClipIndex = 0;

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
            currentExhibitStory = swordStory;
            triggerSwordStory = true;
        }

        if (triggerSwordStory)
        {
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerSwordStory = false;
        }
    }

    private void PlayAudio(StoryPart[] exhibitStory, int audioClipIndex)
    {
        if(audioClipIndex >= exhibitStory.Length) { return; }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(exhibitStory[audioClipIndex].audioClip);
            StartCoroutine(WaitThenDisplayQuestions(exhibitStory));
        }
    }

    IEnumerator WaitThenDisplayQuestions(StoryPart[] exhibitStory)
    {
        yield return new WaitForSeconds(exhibitStory[audioClipIndex].audioClip.length);
        ShowOptions(exhibitStory);
        //audioClipIndex++;
        //PlayAudio(exhibitStory, audioClipIndex);
    }

    private void ShowOptions(StoryPart[] exhibitStory)
    {
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
                swordOptionsUI[i].gameObject.SetActive(true);
            }
            swordOptionsUIText[0].GetComponent<Text>().text = swordQuestions[0].question;
            swordOptionsUIText[1].GetComponent<Text>().text = swordQuestions[1].question;
            swordOptionsUIText[2].GetComponent<Text>().text = swordQuestions[2].question;
        }
        else if (exhibitStory[audioClipIndex].numberOfOptions == 2)
        {
            if(exhibitStory[audioClipIndex].index == currentExhibitStory[1].index || exhibitStory[audioClipIndex].index == currentExhibitStory[4].index || exhibitStory[audioClipIndex].index == currentExhibitStory[5].index)
            {
                for (int i = 3; i < 5; i++)  // change number to a variable
                {
                    swordOptionsUI[i].gameObject.SetActive(true);
                }
                swordOptionsUIText[3].GetComponent<Text>().text = swordQuestions[3].question;
                swordOptionsUIText[4].GetComponent<Text>().text = swordQuestions[4].question;
            }
            else if (exhibitStory[audioClipIndex].index == currentExhibitStory[2].index || exhibitStory[audioClipIndex].index == currentExhibitStory[6].index || exhibitStory[audioClipIndex].index == currentExhibitStory[7].index)
            {
                for (int i = 5; i < 7; i++)  // change number to a variable
                {
                    swordOptionsUI[i].gameObject.SetActive(true);
                }
                swordOptionsUIText[5].GetComponent<Text>().text = swordQuestions[5].question;
                swordOptionsUIText[6].GetComponent<Text>().text = swordQuestions[6].question;
            }
            else if (exhibitStory[audioClipIndex].index == currentExhibitStory[3].index || exhibitStory[audioClipIndex].index == currentExhibitStory[8].index || exhibitStory[audioClipIndex].index == currentExhibitStory[9].index)
            {
                for (int i = 7; i < 9; i++)  // change number to a variable
                {
                    swordOptionsUI[i].gameObject.SetActive(true);
                }
                swordOptionsUIText[7].GetComponent<Text>().text = swordQuestions[7].question;
                swordOptionsUIText[8].GetComponent<Text>().text = swordQuestions[8].question;
            }
        }
    }

    public void ChooseSwordOption1()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[0].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[0].interactable = false;

        audioClipIndex = currentExhibitStory[1].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption2()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[1].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[1].interactable = false;

        audioClipIndex = currentExhibitStory[2].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption3()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[2].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[2].interactable = false;

        audioClipIndex = currentExhibitStory[3].index;
        PlayAudio(currentExhibitStory, audioClipIndex);
    }

    public void ChooseSwordOption4()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[3].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[3].interactable = false;

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
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[4].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[4].interactable = false;

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
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[5].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[5].interactable = false;

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
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[6].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[6].interactable = false;

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
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[7].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[7].interactable = false;

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
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[8].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[8].interactable = false;

        audioClipIndex = currentExhibitStory[9].index;
        PlayAudio(currentExhibitStory, audioClipIndex);

        currentExhibitStory[audioClipIndex].hasFinished = true;

        if (currentExhibitStory[8].hasFinished && currentExhibitStory[9].hasFinished)
        {
            currentExhibitStory[audioClipIndex].numberOfOptions = 3;
        }
    }
}