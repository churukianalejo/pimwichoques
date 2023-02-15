using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            cameraController(camera1, camera2);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            cameraController(camera2, camera1);
        }
    }

    private void cameraController(CinemachineVirtualCamera turnOn, CinemachineVirtualCamera turnOff)
    {
        turnOn.gameObject.SetActive(true);
        turnOff.gameObject.SetActive(false);
    }
}
