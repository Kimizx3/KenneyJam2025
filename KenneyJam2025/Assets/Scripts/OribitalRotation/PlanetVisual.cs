using System;
using UnityEngine;

public class PlanetVisual : MonoBehaviour
{
    public Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        Vector3 camForward = mainCamera.transform.forward;
        transform.forward = -camForward;
    }
}
