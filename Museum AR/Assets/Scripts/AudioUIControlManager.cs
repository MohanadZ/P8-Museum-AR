using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIControlManager : MonoBehaviour
{
    [SerializeField] Button skipButton = null, playPauseButton = null;
    [SerializeField] Image npcTalkingIndicator = null, npcTalkingIndicatorIcon = null, playPauseIcon = null;
    [SerializeField] Sprite playSprite = null, npcNotTalkingIndicator = null;
    [SerializeField] AudioClip[] pausingVoiceLines = null, uspausingVoiceLines = null, skippingVoiceLines = null;

    Sprite defaultPauseSprite, defaultTalkingIndicatorSprite;
    ExhibitAudioManager exhibitAudioManager;
    NPCManager npc;
    AudioSource audioSource;

    enum AudioAction { Pause, Unpause, Skip}
    AudioAction audioAction;

    public Button SkipButton { get { return skipButton; } }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        npc = FindObjectOfType<NPCManager>();
        defaultPauseSprite = playPauseIcon.GetComponent<Image>().sprite;
        defaultTalkingIndicatorSprite = npcTalkingIndicatorIcon.sprite;
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        npcTalkingIndicator.gameObject.SetActive(false);
        npc.gameObject.SetActive(false);
    }

    void Update()
    {
        TalkingIcon();
    }

    public void PlayPause()
    {
        if (playPauseIcon.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseIcon.GetComponent<Image>().sprite = playSprite;
            audioAction = AudioAction.Pause;
            PlayRandomVoiceLine(pausingVoiceLines, audioAction);
        }
        else
        {
            playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
            audioAction = AudioAction.Unpause;
            PlayRandomVoiceLine(uspausingVoiceLines, audioAction);
        }
    }

    public void Skip()
    {
        playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
        audioAction = AudioAction.Skip;
        PlayRandomVoiceLine(skippingVoiceLines, audioAction);

        //if (exhibitAudioManager.AudioClipIndex < exhibitAudioManager.CurrentExhibitStory.Length)
        //{
        //    //StopCoroutine(exhibitAudioManager.Coroutine);
        //}
    }

    private void TalkingIcon()
    {
        if (exhibitAudioManager.GetAudioSource.isPlaying || audioSource.isPlaying)
        {
            npcTalkingIndicatorIcon.sprite = defaultTalkingIndicatorSprite;
            npcTalkingIndicator.gameObject.SetActive(true);
            playPauseButton.gameObject.SetActive(true);
            skipButton.gameObject.SetActive(true);
            npc.gameObject.SetActive(true);
            npc.ChangeExhibitNPC();
        }
        else
        {
            npcTalkingIndicatorIcon.sprite = npcNotTalkingIndicator;
            //npc.gameObject.SetActive(false);
        }
    }

    public void HideAudioControlUI()
    {
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        //npcTalkingIndicator.gameObject.SetActive(false);
    }

    public void HideNPC()
    {
        npc.gameObject.SetActive(false);
    }

    private void PlayRandomVoiceLine(AudioClip[] randomAudioClip, AudioAction action)
    {
        int randomIndex = Random.Range(0, randomAudioClip.Length);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(randomAudioClip[randomIndex]);
        }

        switch (action)
        {
            case AudioAction.Pause:
                StartCoroutine(PauseExhibitAudioThenWait());
                break;
            case AudioAction.Unpause:
                StartCoroutine(WaitThenUnpauseExhibitAudio());
                break;
            case AudioAction.Skip:
                StartCoroutine(WaitThenSkipExhibitAudio());
                break;
        }
    }

    IEnumerator PauseExhibitAudioThenWait()
    {
        exhibitAudioManager.GetAudioSource.Pause();
        exhibitAudioManager.IsDisplayQuestions = false;
        DisableControlInteraction();

        yield return new WaitUntil(() => !audioSource.isPlaying);
        AllowControlInteraction();
    }

    IEnumerator WaitThenUnpauseExhibitAudio()
    {
        DisableControlInteraction();
        yield return new WaitUntil(() => !audioSource.isPlaying);

        exhibitAudioManager.GetAudioSource.UnPause();
        exhibitAudioManager.IsDisplayQuestions = true;
        AllowControlInteraction();
    }

    IEnumerator WaitThenSkipExhibitAudio()
    {
        exhibitAudioManager.GetAudioSource.Stop();
        exhibitAudioManager.IsDisplayQuestions = false;
        DisableControlInteraction();
        yield return new WaitUntil(() => !audioSource.isPlaying);

        exhibitAudioManager.IsDisplayQuestions = true;
        AllowControlInteraction();
    }

    private void DisableControlInteraction()
    {
        playPauseButton.interactable = false;
        skipButton.interactable = false;
    }

    private void AllowControlInteraction()
    {
        playPauseButton.interactable = true;
        skipButton.interactable = true;
    }
}