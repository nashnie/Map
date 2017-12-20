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

    protected BaseUnitInfo unitInfo;
    protected UnitFrameInfo unitFrameInfo;

    public virtual void Init(BaseUnitInfo unitInfo)
    {
        this.unitInfo = unitInfo;
    }

    public virtual void DoFixedUpdate()
    {
        //TODO moveStep skillStep etc...
        unitFrameInfo = GenericObjectPool<UnitFrameInfo>.Get();
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
        FrameManager.Instance.FireUnitFrameInfo(unitFrameInfo);
    }

    public virtual void Clear()
    {
        canMove = false;
        canRotation = false;
    }

    public virtual void Destroy()
    {
        unitFrameInfo = null;
        unitInfo = null;
    }
}
