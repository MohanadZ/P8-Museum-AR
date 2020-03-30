using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] Button startButton = null, playPauseButton = null, skipButton = null;
    [SerializeField] Image npcTalkingIndicator = null;
    [SerializeField] Sprite playSprite = null;
    [SerializeField] AudioClip[] introduction = null;

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
            Debug.Log("I am here now " + audioClipIndex);

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
        Debug.Log("I am in coroutine");

        yield return new WaitForSeconds(introduction[audioClipIndex].length + 1f);      // Dunno why it does not work if I don't add some time on top of the length of the clip :(
        audioClipIndex++;
        PlayIntroductionStory(introduction, audioClipIndex);
    }

    public void PlayPause()
    {
        if (playPauseButton.GetComponent<Image>().sprite == defaultPauseSprite)
        {
            playPauseButton.GetComponent<Image>().sprite = playSprite;
            audioSource.Pause();
        }
        else
        {
            playPauseButton.GetComponent<Image>().sprite = defaultPauseSprite;
            audioSource.UnPause();
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
            playPauseButton.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(false);
        }
    }
}