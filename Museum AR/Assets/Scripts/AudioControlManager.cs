using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlManager : MonoBehaviour
{
    [SerializeField] Button skipButton = null, playPauseButton = null;
    [SerializeField] Image npcTalkingIndicator = null, playPauseIcon = null;
    [SerializeField] Sprite playSprite = null, npcNotTalkingIndicator = null;

    Sprite defaultPauseSprite, defaultTalkingIndicatorSprite;
    ExhibitAudioManager exhibitAudioManager;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        defaultPauseSprite = playPauseIcon.GetComponent<Image>().sprite;
        defaultTalkingIndicatorSprite = npcTalkingIndicator.sprite;
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        npcTalkingIndicator.gameObject.SetActive(false);
    }

    void Update()
    {
        TalkingIcon();
    }

    public void PlayPause()
    {
        if (playPauseIcon.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseIcon.GetComponent<Image>().sprite = playSprite;
            exhibitAudioManager.audioSource.Pause();
            exhibitAudioManager.isDisplayQuestions = false;
        }
        else
        {
            playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
            exhibitAudioManager.audioSource.UnPause();
            exhibitAudioManager.isDisplayQuestions = true;
        }
    }

    public void Skip()
    {
        exhibitAudioManager.audioSource.Stop();
        exhibitAudioManager.isDisplayQuestions = true;

        if (exhibitAudioManager.audioClipIndex < exhibitAudioManager.currentExhibitStory.Length)
        {
            playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
            StopCoroutine(exhibitAudioManager.coroutine);
        }
    }

    private void TalkingIcon()
    {
        if (exhibitAudioManager.audioSource.isPlaying)
        {
            npcTalkingIndicator.sprite = defaultTalkingIndicatorSprite;
            npcTalkingIndicator.gameObject.SetActive(true);
            playPauseButton.gameObject.SetActive(true);
            skipButton.gameObject.SetActive(true);
        }
        else
        {
            npcTalkingIndicator.sprite = npcNotTalkingIndicator;
        }
    }

    public void HideAudioControlUI()
    {
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
    }
}