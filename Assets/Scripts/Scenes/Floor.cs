using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Bounds levelBounds;

    public CameraMode floorCameraType;

    public List<TransitionGate> floorTransitionGates;

    public float xBoundsMin;
    public float xBoundsMax;
    public float yBoundsMin;
    public float yBoundsMax;

    public Transform cameraFixer;



    private void Start()
    {
        Initialization();

    }

    private void Initialization()
    {
        UpdateFloorBoundaries();
    }


    private void UpdateFloorBoundaries()
    {
        xBoundsMin = levelBounds.min.x;
        xBoundsMax = levelBounds.max.x;
        yBoundsMin = levelBounds.min.y;
        yBoundsMax = levelBounds.max.y;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(levelBounds.center, levelBounds.size);
    }

   

}

