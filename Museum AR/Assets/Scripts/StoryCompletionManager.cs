using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryCompletionManager : MonoBehaviour
{
    ExhibitAudioManager exhibitAudioManager;
    [HideInInspector] public bool isSwordOver;

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
    }
}
