using System.Collections;
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

        animator.speed = animationSpeed;
    }

    public void ChangeExhibitNPC()
    {
        if (exhibitAudioManager.CurrentExhibitStory == null || exhibitAudioManager.CurrentExhibitStory.Length == 0) { return; }
  
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
        else if(exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Sign")
        {
            animator.SetTrigger("Sign");
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Skull")
        {
            animator.SetTrigger("Skull");
        }
        else if(exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Bank")
        {
            animator.SetTrigger("Bank");
        }
    }
}
