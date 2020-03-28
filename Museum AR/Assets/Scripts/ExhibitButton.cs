using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitButton : MonoBehaviour
{
    //[System.Serializable]
    [SerializeField] string title = "";
    [SerializeField] TextAsset exhibitText = null;
    [SerializeField] Sprite sprite = null;
    [SerializeField] ExhibitTag exhibitTag;

    public string Title { get { return title; } }
    public TextAsset ExhibitText { get { return exhibitText; } }
    public Sprite ExhibitImage { get { return sprite; } }
    public ExhibitTag ExhibitTag { get { return exhibitTag; } }

    private void Awake()
    {
        sprite = GetComponent<Sprite>();
    }
}
