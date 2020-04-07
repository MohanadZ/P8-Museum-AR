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
            if(exhibitAudioManager.swordStory[1].hasFinished && exhibitAudioManager.swordStory[2].hasFinished 
                && exhibitAudioManager.swordStory[3].hasFinished)
            {
                isSwordOver = true;
                ExhibitVisitedEvent(ExhibitTag.Sword);
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
        if (!isNeedlesOver)
        {
            if (exhibitAudioManager.needlesStory[1].hasFinished && exhibitAudioManager.needlesStory[2].hasFinished
                && exhibitAudioManager.needlesStory[3].hasFinished)
            {
                isNeedlesOver = true;
                ExhibitVisitedEvent(ExhibitTag.Tattoo);
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
        if (!isTubOver)
        {
            if (exhibitAudioManager.tubStory[1].hasFinished && exhibitAudioManager.tubStory[2].hasFinished
                && exhibitAudioManager.tubStory[3].hasFinished)
            {
                isTubOver = true;
                ExhibitVisitedEvent(ExhibitTag.Bathtub);
                FindObjectOfType<StoryOptionsManager>().DisableOptionsButtons();
            }
        }
    }
}
