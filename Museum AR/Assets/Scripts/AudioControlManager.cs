﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlManager : MonoBehaviour
{
    [SerializeField] Button playPauseButton = null, skipButton = null;
    [SerializeField] Image npcTalkingIndicator = null;
    [SerializeField] Sprite playSprite = null;

    [HideInInspector] public bool isSkip;

    Sprite defaultPauseSprite;
    ExhibitAudioManager exhibitAudioManager;
    StoryOptionsManager storyOptionsManager;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
        defaultPauseSprite = playPauseButton.GetComponent<Image>().sprite;
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
        if (playPauseButton.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseButton.GetComponent<Image>().sprite = playSprite;
            exhibitAudioManager.audioSource.Pause();
            exhibitAudioManager.isDisplayQuestions = false;
        }
        else
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            exhibitAudioManager.audioSource.UnPause();
            exhibitAudioManager.isDisplayQuestions = true;
        }
    }

    public void Skip()
    {
        exhibitAudioManager.audioSource.Stop();
        exhibitAudioManager.isDisplayQuestions = true;
        isSkip = true;

        if (exhibitAudioManager.audioClipIndex < exhibitAudioManager.currentExhibitStory.Length)
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            StopCoroutine(exhibitAudioManager.coroutine);
            storyOptionsManager.ShowOptions(exhibitAudioManager.currentExhibitStory);
        }
    }

    private void TalkingIcon()
    {
        if (exhibitAudioManager.audioSource.isPlaying)
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