using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StoryCompletionManager : MonoBehaviour
{
    ExhibitAudioManager exhibitAudioManager;
    [HideInInspector] public bool isSwordOver;

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
                Debug.Log("SWORD STORY IS OVER. MOVE AWAY!");
            }
        }
    }
}
