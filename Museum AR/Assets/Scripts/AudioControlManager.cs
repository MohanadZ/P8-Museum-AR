using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlManager : MonoBehaviour
{
    [SerializeField] Button skipButton = null, playPauseButton = null;
    [SerializeField] Image npcTalkingIndicator = null, npcTalkingIndicatorIcon = null, playPauseIcon = null;
    [SerializeField] Sprite playSprite = null, npcNotTalkingIndicator = null;

    Sprite defaultPauseSprite, defaultTalkingIndicatorSprite;
    ExhibitAudioManager exhibitAudioManager;
    NPCManager npc;

    public Button SkipButton { get { return skipButton; } }

    void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
        npc = FindObjectOfType<NPCManager>();
        defaultPauseSprite = playPauseIcon.GetComponent<Image>().sprite;
        defaultTalkingIndicatorSprite = npcTalkingIndicatorIcon.sprite;
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        npcTalkingIndicator.gameObject.SetActive(false);
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
            exhibitAudioManager.GetAudioSource.Pause();
            exhibitAudioManager.IsDisplayQuestions = false;
        }
        else
        {
            playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
            exhibitAudioManager.GetAudioSource.UnPause();
            exhibitAudioManager.IsDisplayQuestions = true;
        }
    }

    public void Skip()
    {
        exhibitAudioManager.GetAudioSource.Stop();
        exhibitAudioManager.IsDisplayQuestions = true;

        if (exhibitAudioManager.AudioClipIndex < exhibitAudioManager.CurrentExhibitStory.Length)
        {
            playPauseIcon.GetComponent<Image>().sprite = defaultPauseSprite;
            StopCoroutine(exhibitAudioManager.Coroutine);
        }
    }

    private void TalkingIcon()
    {
        if (exhibitAudioManager.GetAudioSource.isPlaying)
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
            npc.gameObject.SetActive(false);
        }
    }

    public void HideAudioControlUI()
    {
        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        //npcTalkingIndicator.gameObject.SetActive(false);
    }
}