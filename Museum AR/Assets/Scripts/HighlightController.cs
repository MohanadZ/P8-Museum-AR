using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighlightController
{
    private static int numberOfHighlights;
    private static int currentHighlight;
    private static List<int> highlights = new List<int>();
    public static int NumberOfHighlights { get => numberOfHighlights; set => numberOfHighlights = value; }
    public static int CurrentHighlight { get => currentHighlight; set => currentHighlight = value; }
    public static List<int> Highlights { get => highlights; set => highlights = value; }

    public static void InitializeHighlightList()
    {
        Highlights.Insert(0, 0);
    }

    public static void ClearHighlights()
    {
        Highlights.Clear();
        Highlights.Insert(0, 0);
    }

    public static void TriggerSpecifiedHighlight(List<int> index)
    {
        for (int i = 0; i < index.Count; i++)
        {
            Highlights.Insert(i + 1, index[i]);
        }
        
    }

}
