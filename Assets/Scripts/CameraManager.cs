using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera introCam;
    [SerializeField] Camera gameCam;

    IEnumerator Start()
    {
        gameCam.enabled = false;
        introCam.enabled = true;
        yield return new WaitForSeconds(3.5f);
        gameCam.enabled = true;
        introCam.enabled = false;
    }
}
