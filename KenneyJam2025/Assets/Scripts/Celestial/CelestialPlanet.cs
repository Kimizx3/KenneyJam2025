using System;
using UnityEngine;

public class CelestialPlanet : CelestialObjectBase
{
    public CelestialBodyData bodyData;
    public Transform _orbitCenter;

    private float _angle;


    private void Start()
    {
        if (bodyData.bodyName != "Moon")
        {
            _orbitCenter = GalaxyManager.Instance.sunTf;
        }
    }

    private void Update()
    {
        OrbitalRotation();
        VisualScale();
    }

    private void LateUpdate()
    {
        
    }

    private void OrbitalRotation()
    {
        _angle += bodyData.orbitSpeed * Time.deltaTime;
        float rad = _angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(rad) * bodyData.radiusX, 0f, Mathf.Sin(rad) * bodyData.radiusZ);
        transform.position = _orbitCenter.position + offset;
    }
    
    private void VisualScale()
    {
        float dist = Vector3.Distance(transform.position, mainCam.transform.position);
        float scale = baseScale / (1 + dist * scaleFactor);
        scale = Mathf.Clamp(scale, minScale, maxScale);
        transform.localScale = Vector3.one * scale;
    }
}
