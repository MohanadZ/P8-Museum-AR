using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryCompletionManager : MonoBehaviour
{
    [SerializeField] AudioClip swordMoveOn = null, needlesMoveOn = null, tubMoveOn = null,
        signMoveOn = null, skullMoveOn = null, bankMoveOn = null;
    ExhibitAudioManager exhibitAudioManager;
    StoryOptionsManager storyOptionsManager;
    AudioControlManager audioControlManager;
    bool isSwordOver, isNeedlesOver, isTubOver, isSignOver, isSkullOver, isBankOver;

    public bool IsSwordOver { get { return isSwordOver; } }
    public bool IsNeedlesOver { get { return isNeedlesOver; } }
    public bool IsTubOver { get { return isTubOver; } }
    public bool IsSignOver { get { return isSignOver; } }
    public bool IsSkullOver { get { return isSkullOver; } }
    public bool IsBankOver { get { return isBankOver; } }

    public static event Action<ExhibitTag> ExhibitVisitedEvent;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
        audioControlManager = FindObjectOfType<AudioControlManager>();
    }

    public void CheckExhibitCompletion()
    {
        if (!isSwordOver)
        {
            if(exhibitAudioManager.SwordStory[1].hasFinished && exhibitAudioManager.SwordStory[2].hasFinished 
                && exhibitAudioManager.SwordStory[3].hasFinished)
            {
                isSwordOver = true;
                ExhibitVisitedEvent(ExhibitTag.Sword);
                MoveOnToNextExhibit(swordMoveOn);
            }
        }
        if (!isNeedlesOver)
        {
            if (exhibitAudioManager.NeedlesStory[1].hasFinished && exhibitAudioManager.NeedlesStory[2].hasFinished
                && exhibitAudioManager.NeedlesStory[3].hasFinished)
            {
                isNeedlesOver = true;
                ExhibitVisitedEvent(ExhibitTag.Tattoo);
                MoveOnToNextExhibit(needlesMoveOn);
            }
        }
        if (!isTubOver)
        {
            if (exhibitAudioManager.TubStory[1].hasFinished && exhibitAudioManager.TubStory[2].hasFinished
                && exhibitAudioManager.TubStory[3].hasFinished)
            {
                isTubOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bathtub);
                MoveOnToNextExhibit(tubMoveOn);
            }
        }
        if (!isSignOver)
        {
            if (exhibitAudioManager.SignStory[1].hasFinished && exhibitAudioManager.SignStory[2].hasFinished
                && exhibitAudioManager.SignStory[3].hasFinished)
            {
                isSignOver = true;
                ExhibitVisitedEvent(ExhibitTag.Petrea);
                MoveOnToNextExhibit(signMoveOn);
            }
        }
        if (!isSkullOver)
        {
            if (exhibitAudioManager.SkullStory[1].hasFinished && exhibitAudioManager.SkullStory[2].hasFinished
                && exhibitAudioManager.SkullStory[3].hasFinished)
            {
                isSkullOver = true;
                ExhibitVisitedEvent(ExhibitTag.Skull);
                MoveOnToNextExhibit(skullMoveOn);
            }
        }
        if (!isBankOver)
        {
            if (exhibitAudioManager.BankStory[1].hasFinished && exhibitAudioManager.BankStory[2].hasFinished
                && exhibitAudioManager.BankStory[3].hasFinished)
            {
                isBankOver = true;
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
        audioControlManager.SkipButton.interactable = false;
        StartCoroutine(WaitThenCompleteExhibit());
    }

    IEnumerator WaitThenCompleteExhibit()
    {
        yield return new WaitUntil(() => !exhibitAudioManager.GetAudioSource.isPlaying && exhibitAudioManager.IsDisplayQuestions);
        storyOptionsManager.DisableOptionsButtons();
        audioControlManager.HideAudioControlUI();
    }
}