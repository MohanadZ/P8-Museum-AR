﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    Animator animator;
    ExhibitAudioManager exhibitAudioManager;
    float animationSpeed = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
    }

    public void ChangeExhibitNPC()
    {
        if (exhibitAudioManager.CurrentExhibitStory == null || exhibitAudioManager.CurrentExhibitStory.Length == 0) { return; }

        animator.speed = animationSpeed;
        if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Sword")
        {
            animator.SetTrigger("Sword");
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Needles")
        {
            animator.SetTrigger("Needles");
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Tub")
        {
            animator.SetTrigger("Tub");
        }
    }
}