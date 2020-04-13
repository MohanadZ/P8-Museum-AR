using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighlightController
{
    private static int numberOfHighlights;

    private static int currentHighlight;
    public static int NumberOfHighlights { get => numberOfHighlights; set => numberOfHighlights = value; }
    public static int CurrentHighlight { get => currentHighlight; set => currentHighlight = value; }

    public static void SetNumberOfHighlights(int totalHighlights)
    {
        NumberOfHighlights = totalHighlights;
        CurrentHighlight = 0;
    }
    public static void SwitchToNextHighlight()
    {
        CurrentHighlight++;

        if(CurrentHighlight >= NumberOfHighlights)
        {
            CurrentHighlight = 0;
        }
    }

}
