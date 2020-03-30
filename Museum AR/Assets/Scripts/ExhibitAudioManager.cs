using UnityEngine;
using System.Collections;
using System;

public class ExhibitAudioManager : MonoBehaviour
{
    [SerializeField] CustomAudio[] swordExhibit = null, chestExhibit = null;
    OptionsManager optionsManager;

    void Awake()
    {
        optionsManager = FindObjectOfType<OptionsManager>();

        foreach(CustomAudio sound in swordExhibit)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
        foreach(CustomAudio sound in chestExhibit)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
    }

    public void PlayAudio(string name)
    {
        CustomAudio audioToPlay = null;
        if (StoryManager.swordStoryOngoing)
        {
            audioToPlay = Array.Find(swordExhibit, audio => audio.name == name);
            //Debug.Log("Sword is " + StoryManager.swordStory);
        }
        else if (StoryManager.chestStoryOngoing)
        {
            audioToPlay = Array.Find(chestExhibit, audio => audio.name == name);
            //Debug.Log("Sword is " + StoryManager.chestStory);
        }

        if(audioToPlay == null){ return; }

        if (!audioToPlay.audioSource.isPlaying)
        {
            audioToPlay.audioSource.Play();
            optionsManager.ShowOptions(audioToPlay, name);
        }
    }
}
