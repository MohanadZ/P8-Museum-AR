using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SwitchGuideView : MonoBehaviour
{
    private ModelTargetBehaviour m;
    private int counter;

    void Start()
    {
        m = GetComponent<ModelTargetBehaviour>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchToNextGuideView();


    }

    private void SwitchToNextGuideView()
    {
        int guideViewIndex = m.ModelTarget.GetNumGuideViews();

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (counter == guideViewIndex)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }

            m.ModelTarget.SetActiveGuideViewIndex(counter);

        }
    }
}
