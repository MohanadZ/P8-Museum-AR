using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetContainer : MonoBehaviour
{
    [SerializeField] GameObject astronaut;
    [SerializeField] GameObject drone;

    ObjectTracker objectTracker;

    List<GameObject> imageTargets;

    int localTarget;
    void Start()
    {
        imageTargets = new List<GameObject>();

        imageTargets.Add(astronaut);
        imageTargets.Add(drone);

        ImageTargetController.NumberOfImageTargets = imageTargets.Count;
        localTarget = ImageTargetController.CurrentImageTarget;

        VuforiaARController.Instance.RegisterVuforiaStartedCallback(InitializeObjectTracker);

        ActiavteImageTarget();
    }

    private void InitializeObjectTracker()
    {
        objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
    }

  
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            ImageTargetController.SwitchToNextImageTarget();
        }

        if (localTarget != ImageTargetController.CurrentImageTarget)
        {
            ActiavteImageTarget();
            localTarget = ImageTargetController.CurrentImageTarget;
        }
    }

    private void ActiavteImageTarget()
    {
        objectTracker.Stop();

        foreach (var item in imageTargets)
        {
            item.SetActive(false);
        }

        imageTargets[ImageTargetController.CurrentImageTarget].SetActive(true);

        HighlightController.SetNumberOfHighlights(
            imageTargets[ImageTargetController.CurrentImageTarget].GetComponent<ImageTarget>().NumberOfHighlights);

        objectTracker.Start();
    }
}
