using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedInformationTag : MonoBehaviour
{
    [SerializeField] Text nameLabel;
    MeshRenderer currentMesh;

    void Start()
    {
        currentMesh = GetComponentInParent<MeshRenderer>();    
    }

    void Update()
    {
        FaceCamera();
    }

    private void FaceCamera()
    {
        ChangeActive();

        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namePos;
    }

    private void ChangeActive()
    {
        if(currentMesh.enabled)
        {
            nameLabel.enabled = true;
        }
        else
        {
            nameLabel.enabled = false;
        }
    }
}
