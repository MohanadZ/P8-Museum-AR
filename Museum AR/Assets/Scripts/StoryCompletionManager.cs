using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryCompletionManager : MonoBehaviour
{
    ExhibitAudioManager exhibitAudioManager;
    [HideInInspector] public bool isSwordOver, isNeedlesOver, isTubOver;

    public static event Action<ExhibitTag> ExhibitVisitedEvent;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
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
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
        if (!isNeedlesOver)
        {
            if (exhibitAudioManager.NeedlesStory[1].hasFinished && exhibitAudioManager.NeedlesStory[2].hasFinished
                && exhibitAudioManager.NeedlesStory[3].hasFinished)
            {
                isNeedlesOver = true;
                ExhibitVisitedEvent(ExhibitTag.Tattoo);
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
        if (!isTubOver)
        {
            if (exhibitAudioManager.TubStory[1].hasFinished && exhibitAudioManager.TubStory[2].hasFinished
                && exhibitAudioManager.TubStory[3].hasFinished)
            {
                isTubOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bathtub);
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
    }
}
