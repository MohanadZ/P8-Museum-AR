using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTrigger : MonoBehaviour
{
    [SerializeField] ExhibitAudioManager exhibitAudioManager = null;

    private void Awake()
    {
        exhibitAudioManager.GetComponent<ExhibitAudioManager>();
    }

    public void TriggerHighlight()
    {
        if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Sword")
        {
            
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Needles")
        {
            
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Tub")
        {
            if (exhibitAudioManager.AudioClipIndex == 2)
            {
                HighlightController.HasHighlight = true;
                HighlightController.TriggerSpecifiedHighlight(0);
            }
            else if (exhibitAudioManager.AudioClipIndex == 6)
            {
                HighlightController.HasHighlight = true;
                HighlightController.TriggerSpecifiedHighlight(1);
            }
            else if (exhibitAudioManager.AudioClipIndex == 7)
            {
                HighlightController.HasHighlight = true;
                HighlightController.TriggerSpecifiedHighlight(2);
            }
            else if (exhibitAudioManager.AudioClipIndex == 8)
            {
                HighlightController.HasHighlight = true;
                HighlightController.TriggerSpecifiedHighlight(3);
            }
            else
            {
                HighlightController.HasHighlight = false;
            }
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Sign")
        {
            
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Skull")
        {
            
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Bank")
        {
            
        }
    }
}
