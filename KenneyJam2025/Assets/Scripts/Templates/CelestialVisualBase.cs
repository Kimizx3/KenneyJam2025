using System;
using Unity.Mathematics;
using UnityEngine;

public abstract class CelestialVisualBase : MonoBehaviour
{
    private CelestialPlanet planet;
    [HideInInspector] public Camera mainCamera;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    protected void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        planet = GetComponentInParent<CelestialPlanet>();
    }

    protected void Start()
    {
        _transform.localScale = Vector3.one * planet.bodyData.planetScale;
    }

    protected void LookAtCamera()
    {
        Vector3 dir = mainCamera.transform.position - transform.position;
        dir.y = 0;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Rotate(90, 0 ,0);
        }
    }
}
