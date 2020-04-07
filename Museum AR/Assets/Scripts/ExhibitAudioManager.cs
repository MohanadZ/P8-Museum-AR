﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitAudioManager : MonoBehaviour
{
    [Header("Sword Exhibit")]
    public StoryPart[] swordStory = null;
    [SerializeField] QuestionsText[] swordQuestions = null;

    [Header("Tattoo Needles Exhibit")]
    public StoryPart[] needlesStory = null;
    [SerializeField] QuestionsText[] needlesQuestions = null;

    [Header("Tub Exhibit")]
    public StoryPart[] tubStory = null;
    [SerializeField] QuestionsText[] tubQuestions = null;

    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public StoryPart[] currentExhibitStory = null;
    [HideInInspector] public IEnumerator coroutine;
    [HideInInspector] public int audioClipIndex;
    [HideInInspector] public bool triggerSwordStory, triggerNeedlesStory, triggerTubStory;
    [HideInInspector] public bool isDisplayQuestions = true;
    [HideInInspector] public QuestionsText[] currentStoryQuestions = null;

    StoryOptionsManager storyOptionsManager;
    StoryCompletionManager storyCompletion;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
        storyCompletion = FindObjectOfType<StoryCompletionManager>();
        ResetScriptableObjectsProperties();
    }

    private void ResetScriptableObjectsProperties()
    {
        foreach (StoryPart story in swordStory)
        {
            story.hasFinished = false;
        }
        foreach (StoryPart story in needlesStory)
        {
            story.hasFinished = false;
        }
        foreach (StoryPart story in tubStory)
        {
            story.hasFinished = false;
        }

        for (int i = 4; i < swordStory.Length; i++)
        {
            swordStory[i].numberOfOptions = 2;
            needlesStory[i].numberOfOptions = 2;
            tubStory[i].numberOfOptions = 2;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            triggerSwordStory = true;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            triggerNeedlesStory = true;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            triggerTubStory = true;
        }

        ExhibitStart();
    }

    private void ExhibitStart()
    {
        if (triggerSwordStory && !storyCompletion.isSwordOver)
        {
            storyOptionsManager.ResetOptionsButtons();
            currentExhibitStory = swordStory;
            currentStoryQuestions = swordQuestions;
            audioClipIndex = 0;
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerSwordStory = false;
        }
        else if(triggerNeedlesStory && !storyCompletion.isNeedlesOver)
        {
            storyOptionsManager.ResetOptionsButtons();
            currentExhibitStory = needlesStory;
            currentStoryQuestions = needlesQuestions;
            audioClipIndex = 0;
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerNeedlesStory = false;
        }
        else if (triggerTubStory && !storyCompletion.isTubOver)
        {
            storyOptionsManager.ResetOptionsButtons();
            currentExhibitStory = tubStory;
            currentStoryQuestions = tubQuestions;
            audioClipIndex = 0;
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerTubStory = false;
        }
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
        yield return new WaitUntil(() => !audioSource.isPlaying && isDisplayQuestions);
        storyOptionsManager.ShowOptions(exhibitStory);
    }
}