using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitButton : MonoBehaviour
{
    [SerializeField] Test test = new Test();

    [System.Serializable]
    [SerializeField] struct Test
    {
        [SerializeField] ExhibitName exhibitName;
        [SerializeField] string title;
        [SerializeField] string exhibitText;
        [SerializeField] Image image;
    }

    Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        //Subscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void OnDisable()
    {
        //Unsubscribe to event that triggers once an exhibit has been fully explored/visited
    }

    private void OnExhibitVisited()
    {
        Color temporaryColor = image.color;
        temporaryColor.a = 1f;
        image.color = temporaryColor;
        image.gameObject.tag = "Visited";
    }
}
