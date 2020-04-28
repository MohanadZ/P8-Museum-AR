using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalEvaluationUI : MonoBehaviour
{
    [SerializeField] Text detected;
    Renderer objectRenderer;
    void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        if (objectRenderer.enabled)
        {
            detected.enabled = true;
        }
        else
        {
            detected.enabled = false;
        }
    }
}
