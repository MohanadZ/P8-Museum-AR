using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExhibitButton : MonoBehaviour
{
    //[System.Serializable]
    [SerializeField] string title = "";
    [SerializeField] TextAsset exhibitTextAsset = null;
    [SerializeField] Sprite sprite = null;
    [SerializeField] ExhibitTag exhibitTag;

    private string exhibitText = "";

    public string Title { get { return title; } }
    public string ExhibitText { get { return exhibitText; } }
    public Sprite ExhibitImage { get { return sprite; } }
    public ExhibitTag ExhibitTag { get { return exhibitTag; } }

    private void Awake()
    {
        sprite = GetComponent<Sprite>();
    }

    private void Start()
    {
        exhibitText = exhibitTextAsset.text;
    }
}
