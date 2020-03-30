using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Button option1Button = null, option2Button = null, option3Button = null;
    [SerializeField] Text option1Text = null, option2Text = null, option3Text = null;
    ExhibitAudioManager exhibitAudioManager;

    private void Awake()
    {
        exhibitAudioManager = FindObjectOfType<ExhibitAudioManager>();
    }

    public void ShowOptions(CustomAudio audioToPlay, string name)
    {
        StartCoroutine(WaitThenDisplayQuestions(audioToPlay, name));
    }

    IEnumerator WaitThenDisplayQuestions(CustomAudio audioToPlay, string name)
    {
        yield return new WaitForSeconds(audioToPlay.audioClip.length);
        if (name == "Sword Story Intro")
        {
            option1Button.gameObject.SetActive(true);
            option2Button.gameObject.SetActive(true);
            option3Button.gameObject.SetActive(true);

            option1Text.GetComponent<Text>().text = "Hvad skulle Ulv i Jakobslandene?";
            option2Text.GetComponent<Text>().text = "Hvad er Jakobslandene?";
            option3Text.GetComponent<Text>().text = "Fortæl mig mere om sværdet";
        }
        else if(name == "Question 1.1")
        {
            option1Button.gameObject.SetActive(true);
            option2Button.gameObject.SetActive(true);

            option1Text.GetComponent<Text>().text = "Hvad døde han af?";
            option2Text.GetComponent<Text>().text = "Hov, troede i både på den kristne og de nordiske guder?";
        }
    }

    public void ChooseOption1()
    {
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option3Button.gameObject.SetActive(false);

        option1Button.GetComponent<Image>().color = Color.gray;
        option1Button.interactable = false;

        exhibitAudioManager.PlayAudio("Question 1.1");
    }
}
