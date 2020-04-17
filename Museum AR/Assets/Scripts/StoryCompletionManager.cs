using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryCompletionManager : MonoBehaviour
{
    ExhibitAudioManager exhibitAudioManager;
    StoryOptionsManager storyOptionsManager;
    [HideInInspector] public bool isSwordOver, isNeedlesOver, isTubOver, isSignOver, isSkullOver, isBankOver;

    public static event Action<ExhibitTag> ExhibitVisitedEvent;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
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
                storyOptionsManager.DisableOptionsButtons();
            }
        }
        if (!isNeedlesOver)
        {
            if (exhibitAudioManager.NeedlesStory[1].hasFinished && exhibitAudioManager.NeedlesStory[2].hasFinished
                && exhibitAudioManager.NeedlesStory[3].hasFinished)
            {
                isNeedlesOver = true;
                ExhibitVisitedEvent(ExhibitTag.Tattoo);
                storyOptionsManager.DisableOptionsButtons();
            }
        }
        if (!isTubOver)
        {
            if (exhibitAudioManager.TubStory[1].hasFinished && exhibitAudioManager.TubStory[2].hasFinished
                && exhibitAudioManager.TubStory[3].hasFinished)
            {
                isTubOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bathtub);
                storyOptionsManager.DisableOptionsButtons();
            }
        }
        if (!isSignOver)
        {
            if (exhibitAudioManager.SignStory[1].hasFinished && exhibitAudioManager.SignStory[2].hasFinished
                && exhibitAudioManager.SignStory[3].hasFinished)
            {
                isSignOver = true;
                ExhibitVisitedEvent(ExhibitTag.Petrea);
                storyOptionsManager.DisableOptionsButtons();
            }
        }
        if (!isSkullOver)
        {
            if (exhibitAudioManager.SkullStory[1].hasFinished && exhibitAudioManager.SkullStory[2].hasFinished
                && exhibitAudioManager.SkullStory[3].hasFinished)
            {
                isSkullOver = true;
                ExhibitVisitedEvent(ExhibitTag.Skull);
                storyOptionsManager.DisableOptionsButtons();
            }
        }
        if (!isBankOver)
        {
            if (exhibitAudioManager.BankStory[1].hasFinished && exhibitAudioManager.BankStory[2].hasFinished
                && exhibitAudioManager.BankStory[3].hasFinished)
            {
                isBankOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bank);
                storyOptionsManager.DisableOptionsButtons();
            }
        }
    }
}
