using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExhibitButton : MonoBehaviour
{
    [SerializeField] string title = "";
    [SerializeField] TextAsset exhibitTextAsset = null;
    [SerializeField] Sprite exhibitImage = null;
    [SerializeField] ExhibitTag exhibitTag;

    private string exhibitText = "";

    public string Title { get { return title; } }
    public string ExhibitText { get { return exhibitText; } }
    public Sprite ExhibitImage { get { return exhibitImage; } }
    public ExhibitTag ExhibitTag { get { return exhibitTag; } }

    private void Start()
    {
        exhibitText = exhibitTextAsset.text;
    }
}
