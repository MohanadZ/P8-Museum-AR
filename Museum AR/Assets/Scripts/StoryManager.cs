using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [HideInInspector] public static bool triggerSwordStory = false, triggerChestStory = false;
    [HideInInspector] public static bool swordStoryOngoing = false, chestStoryOngoing = false;
    ExhibitAudioManager exhibitAudioManager;

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            triggerSwordStory = true;
            //triggerChestStory = false;

            swordStoryOngoing = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            triggerChestStory = true;
            //triggerSwordStory = false;

            chestStoryOngoing = true;
        }
        StartStory();
    }

    private void StartStory()
    {
        if (triggerSwordStory)
        {
            exhibitAudioManager.PlayAudio("Sword Story Intro");
            triggerSwordStory = false;
        }
        else if (triggerChestStory)
        {
            exhibitAudioManager.PlayAudio("Chest Story Intro");
            triggerChestStory = false;
        }
    }
}