using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitAudioManager : MonoBehaviour
{
    public StoryPart[] swordStory = null;
    [SerializeField] QuestionsText[] swordQuestions = null;

    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public StoryPart[] currentExhibitStory = null;
    [HideInInspector] public IEnumerator coroutine;
    [HideInInspector] public int audioClipIndex = 0;
    [HideInInspector] public bool triggerSwordStory = false;
    [HideInInspector] public bool isDisplayQuestions = true;
    [HideInInspector] public QuestionsText[] currentStoryQuestions = null;

    StoryOptionsManager storyOptionsManager;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        storyOptionsManager = FindObjectOfType<StoryOptionsManager>();
        ResetScriptableObjectsProperties();
    }

    private void ResetScriptableObjectsProperties()
    {
        foreach (StoryPart story in swordStory)
        {
            story.hasFinished = false;
        }

        for(int i = 4; i < swordStory.Length; i++)
        {
            swordStory[i].numberOfOptions = 2;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            triggerSwordStory = true;
        }

        if (triggerSwordStory)
        {
            storyOptionsManager.ResetOptionsButtons();
            currentExhibitStory = swordStory;
            currentStoryQuestions = swordQuestions;
            PlayAudio(currentExhibitStory, audioClipIndex);
            triggerSwordStory = false;
        }
    }

    public void PlayAudio(StoryPart[] exhibitStory, int audioClipIndex)
    {
        if(audioClipIndex >= exhibitStory.Length) { return; }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(exhibitStory[audioClipIndex].audioClip);
            coroutine = WaitThenDisplayQuestions(exhibitStory);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitThenDisplayQuestions(StoryPart[] exhibitStory)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying && isDisplayQuestions);
        storyOptionsManager.ShowOptions(exhibitStory);
    }
}