using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedInformationTag : MonoBehaviour
{
    [SerializeField] Text nameLabel;

    void Update()
    {
        FaceCamera();
    }

    private void FaceCamera()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namePos;
    }
}
