using System;
using UnityEngine;

public class CelestialVisual : CelestialVisualBase
{
    private void LateUpdate()
    {
        LookAtCamera();
    }
}
