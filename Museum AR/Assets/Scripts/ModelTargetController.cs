using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ModelTargetController : MonoBehaviour
{
    [SerializeField] GameObject iPhoneModelTarget;
    [SerializeField] GameObject spinnerModelTarget;

    private ModelTargetBehaviour mIPhone;
    private ModelTargetBehaviour mSpinner;
    private int counter;

    [SerializeField] bool iPhoneActive;
    [SerializeField] bool spinnerActive;

    void Start()
    {
        iPhoneModelTarget = GetComponent<GameObject>();
        spinnerModelTarget = GetComponent<GameObject>();

        mIPhone = iPhoneModelTarget.GetComponent<ModelTargetBehaviour>();
        mSpinner = spinnerModelTarget.GetComponent<ModelTargetBehaviour>();

        counter = 0;

        iPhoneActive = false;
        spinnerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchModel();
        SwitchGuideView();
    }

    private void SwitchModel()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (spinnerActive)
            {
                spinnerActive = false;
                iPhoneActive = true;
            }
            else
            {
                spinnerActive = true;
                iPhoneActive = false;
            }
        }
    }

    private int IsModelActive()
    {
        int activeModel;

        if(iPhoneActive)
        {
            spinnerActive = false;
            iPhoneModelTarget.SetActive(true);
            spinnerModelTarget.SetActive(false);
            activeModel = 0;
        } else
        {
            iPhoneActive = false;
            iPhoneModelTarget.SetActive(false);
            spinnerModelTarget.SetActive(true);
            activeModel = 1;
        }
       
        return activeModel;
    }

    private void SwitchGuideView()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(IsModelActive() == 0)
            {
                if (counter == mIPhone.ModelTarget.GetNumGuideViews())
                {
                    counter = 0;
                }
                else
                {
                    counter++;
                }

                mIPhone.ModelTarget.SetActiveGuideViewIndex(counter);
            }
            else if(IsModelActive() == 1)
            {
                if (counter == mSpinner.ModelTarget.GetNumGuideViews())
                {
                    counter = 0;
                }
                else
                {
                    counter++;
                }

                mSpinner.ModelTarget.SetActiveGuideViewIndex(counter);
            }
        }
    }
}
