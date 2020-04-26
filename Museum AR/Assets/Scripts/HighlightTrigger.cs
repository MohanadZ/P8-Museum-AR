using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighlightTrigger : MonoBehaviour
{
    [SerializeField] ExhibitAudioManager exhibitAudioManager = null;
    List<int> highlightIndex = new List<int>();

    private void Awake()
    {
        exhibitAudioManager.GetComponent<ExhibitAudioManager>();
        HighlightController.InitializeHighlightList();
    }

    public void TriggerHighlight()
    {
        if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Sword")
        {
            if (exhibitAudioManager.AudioClipIndex == 3)
            {
                // 1 = inscription      2 = middle part of blade
                highlightIndex.Insert(0, 1); 
                highlightIndex.Insert(1, 2);
                HighlightController.TriggerSpecifiedHighlight(highlightIndex);
            }
            else if (exhibitAudioManager.AudioClipIndex == 8)
            {
                highlightIndex.Insert(0, 2);
                highlightIndex.Insert(1, 3);
                highlightIndex.Insert(2, 4);
                HighlightController.TriggerSpecifiedHighlight(highlightIndex);
            }
            else
            {
                if(HighlightController.Highlights.Count > 1)
                {
                    HighlightController.ClearHighlights();
                }
            }
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Tub")
        {
            if (exhibitAudioManager.AudioClipIndex == 2)
            {
                InsertValue(1, 1);
            }
            else if (exhibitAudioManager.AudioClipIndex == 6)
            {
                InsertValue(1, 2);
            }
            else if (exhibitAudioManager.AudioClipIndex == 7)
            {
                InsertValue(1,3);
            }
            else if (exhibitAudioManager.AudioClipIndex == 8)
            {
                InsertValue(1, 4);
            }
            else
            {
                if (HighlightController.Highlights.Count > 1)
                {
                    HighlightController.ClearHighlights();
                }
            }
        }
        else if (exhibitAudioManager.CurrentExhibitStory[0].exhibitTag == "Skull")
        {
            if (exhibitAudioManager.AudioClipIndex == 4)
            {
                highlightIndex.Insert(0, 1);
                HighlightController.TriggerSpecifiedHighlight(highlightIndex);
            }
            else if (exhibitAudioManager.AudioClipIndex == 5)
            {
                highlightIndex.Insert(0, 2);
                HighlightController.TriggerSpecifiedHighlight(highlightIndex);
            }
            else
            {
                if (HighlightController.Highlights.Count > 1)
                {
                    HighlightController.ClearHighlights();
                }
            }
            
        }
    }

    private void InsertValue(int index, int value)
    {
        if (HighlightController.Highlights.Count == index)
        {
            HighlightController.Highlights.Insert(index, value);
        }
        else
        {
            HighlightController.Highlights[index] = value;
        }
    }
}
