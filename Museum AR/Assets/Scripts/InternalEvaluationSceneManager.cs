using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternalEvaluationSceneManager : MonoBehaviour
{
    public void SwitchToBox()
    {
        SceneManager.LoadScene("Box ModelTarget");
    }

    public void SwitchToSword()
    {
        SceneManager.LoadScene("Sword ModelTarget");
    }

    public void SwitchToTub()
    {
        SceneManager.LoadScene("Tub ModelTarget");
    }

}
