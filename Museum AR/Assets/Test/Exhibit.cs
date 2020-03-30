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
        if (exhibitStory[audioClipIndex].hasOptions && exhibitStory[audioClipIndex].numberOfOptions == 3)
        {
            for (int i = 0; i < 3; i++)  // change number to a variable
            {
                swordOptionsUI[i].gameObject.SetActive(true);
            }
            swordOptionsUIText[0].GetComponent<Text>().text = swordQuestions[0].question;
            swordOptionsUIText[1].GetComponent<Text>().text = swordQuestions[1].question;
            swordOptionsUIText[2].GetComponent<Text>().text = swordQuestions[2].question;
        }
        else if (exhibitStory[audioClipIndex].hasOptions && exhibitStory[audioClipIndex].numberOfOptions == 2)
        {
            for (int i = 3; i < 5; i++)  // change number to a variable
            {
                swordOptionsUI[i].gameObject.SetActive(true);
            }
            swordOptionsUIText[3].GetComponent<Text>().text = swordQuestions[3].question;
            swordOptionsUIText[4].GetComponent<Text>().text = swordQuestions[4].question;
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
    }
}