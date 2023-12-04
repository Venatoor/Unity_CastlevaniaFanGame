using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Managers
{


    public CameraMode currentCameraMode;
    public Bounds currentCameraBounds;

    public float halfCameraX;
    public float halfCameraY;

    protected float zAdjustement = -10;
    public float offset;
    // Start is called before the first frame update
    protected override void Initialization()
    {
        base.Initialization();
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y+offset, zAdjustement);
        halfCameraX = GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0, 0)).x;
        halfCameraX = GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0, 0)).x;

        FloorManager.Instance.OnTransitionRequested += AdjustCameraToFloor;

    }

    // Update is called once per frame
    protected virtual void LateUpdate()
    {
        CameraFollow();
    }

    protected virtual void CameraFollow()
    {

        if ( character != null )
        

        
        switch( currentCameraMode)
        {
            case  CameraMode.NON_SCALABLE  :
                break;
            case  CameraMode.X_SCALABLE    :
                transform.position = new Vector3(character.transform.position.x, transform.position.y, zAdjustement);
                break;
            case CameraMode.Y_SCALABLE     :
                transform.position = new Vector3(transform.position.x, character.transform.position.y, zAdjustement);
                break;
            case CameraMode.SCALABLE       :
                transform.position = new Vector3(character.transform.position.x, character.transform.position.y + offset, zAdjustement);
                break;
        }
        SetNewCameraBoundaries(FloorManager.Instance.GetCurrentFloor());
    }

    //USABLE FOR OBSERVER IN TRANSITION
    public  void AdjustCameraToFloor(Floor floor, CameraMode cameraMode)
    {
        transform.position = floor.cameraFixer.transform.position;
        currentCameraMode = cameraMode;
    }


    public void SetNewCameraBoundaries(Floor floor)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, FloorManager.Instance.GetCurrentFloorBoundsMinX() - halfCameraX, FloorManager.Instance.GetCurrentFloorBoundsMaxX() + halfCameraX
            ), Mathf.Clamp(transform.position.y, FloorManager.Instance.GetCurrentFloorBoundsMinY() - halfCameraY, FloorManager.Instance.GetCurrentFloorBoundsMaxY()), zAdjustement);
    }




    protected virtual void ChangeCameraBackground()
    {
    }
}

public enum CameraMode
{
    NON_SCALABLE, X_SCALABLE, Y_SCALABLE, SCALABLE,
}
