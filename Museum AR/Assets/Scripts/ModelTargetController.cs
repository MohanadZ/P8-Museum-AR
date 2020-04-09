using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ModelTargetController : MonoBehaviour
{
    [SerializeField] GameObject modelTarget;

    ModelTargetBehaviour mModelTarget;

    ObjectTracker objectTracker;

    string dataSetName;

    int counter;

    IEnumerable<DataSet> dataSets;

    void Start()
    {

        mModelTarget = modelTarget.GetComponent<ModelTargetBehaviour>();

        counter = 0;

        dataSetName = "Car";

        VuforiaARController.Instance.RegisterVuforiaStartedCallback(InitializeObjectTracker);
    }

    private void InitializeObjectTracker()
    {
        objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        dataSets = objectTracker.GetDataSets();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchDatabase();
        SwitchGuideView();
    }

    private void SwitchDatabase()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            IEnumerable<DataSet> activeDataSets = objectTracker.GetActiveDataSets();
            List<DataSet> activeDataSetsToBeRemoved = new List<DataSet>();
            activeDataSetsToBeRemoved.AddRange(activeDataSets);
            // Debug.Log("Number of Datasets in Total: " + activeDataSetsToBeRemoved.Count);

            foreach (DataSet set in activeDataSetsToBeRemoved)
            {
                objectTracker.DeactivateDataSet(set);
            }

            objectTracker.Stop();

            //foreach (DataSet set in dataSets)
            //{
            //    if (set.Path.Contains(dataSetName))
            //    {
            //        objectTracker.ActivateDataSet(set);
            //    }
            //}

            DataSet dataSet = objectTracker.CreateDataSet();

            if (DataSet.Exists(dataSetName))
            {
                dataSet.Load(dataSetName);
                objectTracker.ActivateDataSet(dataSet);
            }


            IEnumerable<TrackableBehaviour> trackableBehaviours = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
            foreach(TrackableBehaviour tb in trackableBehaviours)
            {
                if(tb is ModelTargetBehaviour && tb.isActiveAndEnabled)
                {
                    Debug.Log("TrackableName: " + tb.TrackableName);
                    (tb as ModelTargetBehaviour).GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.GuideView2D;
                    mModelTarget = tb.GetComponent<ModelTargetBehaviour>();
                }
            }

            objectTracker.Start();

        }
    }

    private void SwitchGuideView()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (counter == mModelTarget.ModelTarget.GetNumGuideViews() - 1)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }

            mModelTarget.ModelTarget.SetActiveGuideViewIndex(counter);

        }
    }
}
