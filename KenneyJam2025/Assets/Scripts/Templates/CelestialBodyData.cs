using UnityEngine;

[CreateAssetMenu(menuName = "Galaxy/Celestial Body Data")]
public class CelestialBodyData : ScriptableObject
{
    public string bodyName;
    public float radiusX;
    public float radiusZ;
    public float orbitSpeed;
    public float planetScale;
    public float rotationSpeed;
}
