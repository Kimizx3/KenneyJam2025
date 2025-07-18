using System;
using UnityEngine;

public class GalaxyManager : MonoBehaviour
{
    public static GalaxyManager Instance;
    public Transform sunTf;

    private void Awake()
    {
        Instance = this;
    }
}
