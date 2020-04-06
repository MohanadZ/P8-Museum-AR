using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SwitchGuideView : MonoBehaviour
{
    [SerializeField] ModelTarget m;
    int i;

    void Start()
    {
        i = 0;
        m = gameObject.GetComponent<ModelTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            if(i == 0)
            {
                i = 1;
                m.SetActiveGuideViewIndex(0);
            } else
            {
                i = 0;
                m.SetActiveGuideViewIndex(1);
            }
            
        }
    }
}
