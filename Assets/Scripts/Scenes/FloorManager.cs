using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : Managers
{

    public Floor currentFloor;

    private static FloorManager instance;

    public event System.Action<Floor, CameraMode> OnTransitionRequested;

    public static FloorManager Instance
    {
        get
        {
            if ( instance == null )
            {
                GameObject obj = new GameObject("Floor Manager");
                obj.AddComponent<FloorManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public float GetCurrentFloorBoundsMinX()
    {
        return currentFloor.xBoundsMin;
    }

    public float GetCurrentFloorBoundsMinY()
    {
        return currentFloor.yBoundsMin;
    }

    public float GetCurrentFloorBoundsMaxX()
    {
        return currentFloor.xBoundsMax;
    }

    public float GetCurrentFloorBoundsMaxY()
    {
        return currentFloor.yBoundsMax;
    }


    public Floor GetCurrentFloor()
    {
        return currentFloor;
    }

    // USABLE FOR OBSERVER IN TRANSITION
    public void UpdateFloor( Floor floor)
    {
        currentFloor = floor;
    }

    public void PrepareTransition(Floor floor)
    {
        OnTransitionRequested?.Invoke(floor, floor.floorCameraType);
    }
   



}
