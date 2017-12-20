using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSG.MeshAnimator;

/// <summary>
/// unit logic
/// Nash
/// </summary>
public class BaseUnit
{
    public bool canMove = false;
    public Vector3 position;
    public bool canRotation = false;
    public float rotation;
    public UnitFrameInfo unitFrameInfo;

    public BaseUnitInfo myInfo;

    public virtual void Init(BaseUnitInfo unitInfo)
    {
        this.myInfo = unitInfo;
    }

    public virtual void DoFixedUpdate()
    {
        //TODO moveStep skillStep etc...
        unitFrameInfo = GenericObjectPool<UnitFrameInfo>.Get();
        unitFrameInfo.frame = FrameManager.currentNetworkFrame;
        unitFrameInfo.canMove = canMove;
        unitFrameInfo.canRotate = canRotation;
        if (canMove)
        {
            unitFrameInfo.position = position;
        }
        if (canRotation)
        {
            unitFrameInfo.rotation = rotation;
        }
        Debug.Log("DoFixedUpdate...");
    }

    public virtual void Clear()
    {
        canMove = false;
        canRotation = false;
    }

    public virtual void Destroy()
    {
        unitFrameInfo = null;
        myInfo = null;
    }
}
