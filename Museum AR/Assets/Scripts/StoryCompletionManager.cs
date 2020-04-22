﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryCompletionManager : MonoBehaviour
{
    [SerializeField] AudioClip swordMoveOn = null, needlesMoveOn = null, tubMoveOn = null,
        signMoveOn = null, skullMoveOn = null, bankMoveOn = null;
    ExhibitAudioManager exhibitAudioManager;
    StoryOptionsManager storyOptionsManager;
    AudioUIControlManager audioUIControlManager;

    public bool IsSwordOver { get; private set; }
    public bool IsNeedlesOver { get; private set; }
    public bool IsTubOver { get; private set; }
    public bool IsSignOver { get; private set; }
    public bool IsSkullOver { get; private set; }
    public bool IsBankOver { get; private set; }

    public static event Action<ExhibitTag> ExhibitVisitedEvent;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
        audioUIControlManager = FindObjectOfType<AudioUIControlManager>();
    }

    public void CheckExhibitCompletion()
    {
        if (!IsSwordOver)
        {
            if(exhibitAudioManager.SwordStory[1].hasFinished && exhibitAudioManager.SwordStory[2].hasFinished 
                && exhibitAudioManager.SwordStory[3].hasFinished)
            {
                IsSwordOver = true;
                ExhibitVisitedEvent(ExhibitTag.Sword);
                MoveOnToNextExhibit(swordMoveOn);
            }
        }
        if (!IsNeedlesOver)
        {
            if (exhibitAudioManager.NeedlesStory[1].hasFinished && exhibitAudioManager.NeedlesStory[2].hasFinished
                && exhibitAudioManager.NeedlesStory[3].hasFinished)
            {
                IsNeedlesOver = true;
                ExhibitVisitedEvent(ExhibitTag.Tattoo);
                MoveOnToNextExhibit(needlesMoveOn);
            }
        }
        if (!IsTubOver)
        {
            if (exhibitAudioManager.TubStory[1].hasFinished && exhibitAudioManager.TubStory[2].hasFinished
                && exhibitAudioManager.TubStory[3].hasFinished)
            {
                IsTubOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bathtub);
                MoveOnToNextExhibit(tubMoveOn);
            }
        }
        if (!IsSignOver)
        {
            if (exhibitAudioManager.SignStory[1].hasFinished && exhibitAudioManager.SignStory[2].hasFinished
                && exhibitAudioManager.SignStory[3].hasFinished)
            {
                IsSignOver = true;
                ExhibitVisitedEvent(ExhibitTag.Petrea);
                MoveOnToNextExhibit(signMoveOn);
            }
        }
        if (!IsSkullOver)
        {
            if (exhibitAudioManager.SkullStory[1].hasFinished && exhibitAudioManager.SkullStory[2].hasFinished
                && exhibitAudioManager.SkullStory[3].hasFinished)
            {
                IsSkullOver = true;
                ExhibitVisitedEvent(ExhibitTag.Skull);
                MoveOnToNextExhibit(skullMoveOn);
            }
        }
        if (!IsBankOver)
        {
            if (exhibitAudioManager.BankStory[1].hasFinished && exhibitAudioManager.BankStory[2].hasFinished
                && exhibitAudioManager.BankStory[3].hasFinished)
            {
                IsBankOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bank);
                MoveOnToNextExhibit(bankMoveOn);
            }
        }
    }

    private void MoveOnToNextExhibit(AudioClip audioClip)
    {
        exhibitAudioManager.GetAudioSource.PlayOneShot(audioClip);
        for(int i = 0; i < storyOptionsManager.StoryUIButtons.Length; i++)
        {
            storyOptionsManager.StoryUIButtons[i].interactable = false;
        }
        audioUIControlManager.SkipButton.interactable = false;
        StartCoroutine(WaitThenCompleteExhibit());
    }

    IEnumerator WaitThenCompleteExhibit()
    {
        yield return new WaitUntil(() => !exhibitAudioManager.GetAudioSource.isPlaying && exhibitAudioManager.IsDisplayQuestions);
        storyOptionsManager.DisableOptionsButtons();
        audioUIControlManager.HideAudioControlUI();
        audioUIControlManager.HideNPC();
    }
}