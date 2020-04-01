using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlManager : MonoBehaviour
{
    [SerializeField] Button playPauseButton = null, skipButton = null;
    [SerializeField] Image npcTalkingIndicator = null;
    [SerializeField] Sprite playSprite = null;
    Sprite defaultPauseSprite;

    Exhibit exhibit;

    void Awake()
    {
        exhibit = FindObjectOfType<Exhibit>();
        defaultPauseSprite = playPauseButton.GetComponent<Image>().sprite;
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        npcTalkingIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        TalkingIcon();
    }

    //public void ShowAudioControlUI()
    //{
    //    playPauseButton.gameObject.SetActive(true);
    //    skipButton.gameObject.SetActive(true);
    //}

    public void PlayPause()
    {
        if (playPauseButton.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseButton.GetComponent<Image>().sprite = playSprite;
            exhibit.audioSource.Pause();
            exhibit.isDisplayQuestions = false;
        }
        else
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            exhibit.audioSource.UnPause();
            exhibit.isDisplayQuestions = true;
        }
    }

    public void Skip()
    {
        exhibit.audioSource.Stop();
        exhibit.isDisplayQuestions = true;
        //exhibit.audioClipIndex++;
        if (exhibit.audioClipIndex < exhibit.currentExhibitStory.Length)
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            //exhibit.PlayAudio(exhibit.currentExhibitStory, exhibit.audioClipIndex);
            //Debug.Log(exhibit.audioClipIndex);
            StopCoroutine(exhibit.coroutine);
            exhibit.ShowOptions(exhibit.currentExhibitStory);
        }
        //else
        //{
        //    TO DO: Go back to main questions with them being greyed out
        //    Debug.Log("STORY IS OVER");
        //}
    }

    private void TalkingIcon()
    {
        if (exhibit.audioSource.isPlaying)
        {
            npcTalkingIndicator.gameObject.SetActive(true);
            playPauseButton.gameObject.SetActive(true);
            skipButton.gameObject.SetActive(true);
        }
        else
        {
            npcTalkingIndicator.gameObject.SetActive(false);
        }
    }

    public void HideAudioControlUI()
    {
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
    }
}