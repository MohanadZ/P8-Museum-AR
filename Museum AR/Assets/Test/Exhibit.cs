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
    int audioClipIndex;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClipIndex = swordStory[0].index;
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
            PlayAudio(swordStory, audioClipIndex);
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
            if(exhibitStory[audioClipIndex].index == swordStory[1].index || exhibitStory[audioClipIndex].index == swordStory[4].index || exhibitStory[audioClipIndex].index == swordStory[5].index)
            {
                for (int i = 3; i < 5; i++)  // change number to a variable
                {
                    swordOptionsUI[i].gameObject.SetActive(true);
                }
                swordOptionsUIText[3].GetComponent<Text>().text = swordQuestions[3].question;
                swordOptionsUIText[4].GetComponent<Text>().text = swordQuestions[4].question;
            }
            else if (exhibitStory[audioClipIndex].index == swordStory[2].index || exhibitStory[audioClipIndex].index == swordStory[6].index || exhibitStory[audioClipIndex].index == swordStory[7].index)
            {
                for (int i = 5; i < 7; i++)  // change number to a variable
                {
                    swordOptionsUI[i].gameObject.SetActive(true);
                }
                swordOptionsUIText[5].GetComponent<Text>().text = swordQuestions[5].question;
                swordOptionsUIText[6].GetComponent<Text>().text = swordQuestions[6].question;
            }
            else if (exhibitStory[audioClipIndex].index == swordStory[3].index || exhibitStory[audioClipIndex].index == swordStory[8].index || exhibitStory[audioClipIndex].index == swordStory[9].index)
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

        audioClipIndex = swordStory[1].index;
        PlayAudio(swordStory, audioClipIndex);
    }

    public void ChooseSwordOption2()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[1].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[1].interactable = false;

        audioClipIndex = swordStory[2].index;
        PlayAudio(swordStory, audioClipIndex);
    }

    public void ChooseSwordOption3()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[2].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[2].interactable = false;

        audioClipIndex = swordStory[3].index;
        PlayAudio(swordStory, audioClipIndex);
    }

    public void ChooseSwordOption4()
    {
        for (int i = 0; i < swordOptionsUI.Length; i++)
        {
            swordOptionsUI[i].gameObject.SetActive(false);
        }
        swordOptionsUI[3].GetComponent<Image>().color = Color.gray;
        swordOptionsUI[3].interactable = false;

        audioClipIndex = swordStory[4].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if(swordStory[4].hasFinished && swordStory[5].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
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

        audioClipIndex = swordStory[5].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if (swordStory[4].hasFinished && swordStory[5].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
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

        audioClipIndex = swordStory[6].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if(swordStory[6].hasFinished && swordStory[7].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
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

        audioClipIndex = swordStory[7].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if (swordStory[6].hasFinished && swordStory[7].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
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

        audioClipIndex = swordStory[8].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if (swordStory[8].hasFinished && swordStory[9].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
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

        audioClipIndex = swordStory[9].index;
        PlayAudio(swordStory, audioClipIndex);

        swordStory[audioClipIndex].hasFinished = true;

        if (swordStory[8].hasFinished && swordStory[9].hasFinished)
        {
            swordStory[audioClipIndex].numberOfOptions = 3;
        }
    }
}