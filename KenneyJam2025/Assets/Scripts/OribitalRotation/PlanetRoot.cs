using System;
using UnityEngine;

public class PlanetRoot : MonoBehaviour
{
    public Transform center;
    public Camera mainCam;
    public float orbitSpeed = 10f;
    public float radiusX = 50f;
    public float radiusZ = 80f;
    private float _angle;
    
    public float baseScale = 1f;
    public float scaleFactor = 0.05f;
    public float minScale = 0.2f;
    public float maxScale = 1.2f;
    
    private void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    
    private void Update()
    {
        _angle += orbitSpeed * Time.deltaTime;
        float rad = _angle * Mathf.Deg2Rad;
        float xAxis = Mathf.Cos(rad) * radiusX;
        float zAxis = Mathf.Sin(rad) * radiusZ;
        transform.position = center.position + new Vector3(xAxis, 0, zAxis);

        float dist = Vector3.Distance(transform.position, mainCam.transform.position);

        float scale = baseScale / (1 + dist * scaleFactor);
        scale = Mathf.Clamp(scale, minScale, maxScale);

        transform.localScale = Vector3.one * scale;
    }
}
