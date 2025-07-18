using System;
using UnityEngine;

public abstract class CelestialObjectBase : MonoBehaviour
{
    [Header("Visual Base Config")] 
    public float baseScale = 1f;
    public float scaleFactor = 0.04f;
    public float minScale = 0.2f;
    public float maxScale = 1.5f;

    [HideInInspector] 
    public Camera mainCam;

    protected void Awake()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
}
