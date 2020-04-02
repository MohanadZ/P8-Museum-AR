using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Button startButton = null, playPauseButton = null, skipButton = null;
    [SerializeField] Image npcTalkingIndicator = null;
    [SerializeField] Sprite playSprite = null;
    [SerializeField] AudioClip[] introduction = null;
    bool isNextClip = true;

    Sprite defaultPauseSprite;
    AudioSource audioSource;
    int audioClipIndex = 0;
    bool isIntroOver = false;

    private void Awake()
    {
        defaultPauseSprite = playPauseButton.GetComponent<Image>().sprite;
        audioSource = GetComponent<AudioSource>();

        playPauseButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        npcTalkingIndicator.gameObject.SetActive(false);
    }

    private void Update()
    {
        TalkingIcon();
        IntroductionFinish();
    }

    public void StartJourney()
    {
        startButton.gameObject.SetActive(false);
        playPauseButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);

        PlayIntroductionStory(introduction, audioClipIndex);
    }

    private void PlayIntroductionStory(AudioClip[] introduction, int audioClipIndex)
    {
        if (audioClipIndex >= introduction.Length) { isIntroOver = true; return; }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(introduction[audioClipIndex]);
            StartCoroutine(WaitThenResumeAudio());
        }
        else if(audioSource.isPlaying)
        {
            Debug.Log("AUDIO IS CURRENTLY PLAYING");
        }
    }

    IEnumerator WaitThenResumeAudio()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying && isNextClip);
        audioClipIndex++;
        PlayIntroductionStory(introduction, audioClipIndex);
    }

    public void PlayPause()
    {
        if (playPauseButton.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseButton.GetComponent<Image>().sprite = playSprite;
            audioSource.Pause();
            isNextClip = false;
        }
        else
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            audioSource.UnPause();
            isNextClip = true;
        }
    }

    public void Skip()
    {
        audioSource.Stop();
        audioClipIndex++;
        if (audioClipIndex < introduction.Length)
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            PlayIntroductionStory(introduction, audioClipIndex);
        }
        else
        {
            isIntroOver = true;
        }
    }

    private void TalkingIcon()
    {
        if (audioSource.isPlaying)
        {
            npcTalkingIndicator.gameObject.SetActive(true);
        }
        else
        {
            npcTalkingIndicator.gameObject.SetActive(false);
        }
    }

    private void IntroductionFinish()
    {
        if (isIntroOver)
        {
            SceneManager.LoadScene(1);
        }
    }
}